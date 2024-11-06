namespace QuizmasterGame.ConsoleApp;

using System.Runtime.InteropServices;
using QuizmasterGame.Core;

internal class Program
{
    private static void Main(string[] args)
    {
        string relativePath = @"..\data\questions.json";
        string fullPath = Path.GetFullPath(relativePath);

        System.Console.WriteLine($"Welcome to Quizmaster!");

        try
        {
            // Load questions using JsonQuestionLoader
            var questionLoader = new JsonQuestionLoader(fullPath);

            // Create an instance of QuizmasterGame
            var quizmasterGame = new QuizmasterGame("Quiz Game");

            // Use the Questions property to access the loaded questions
            foreach (var question in questionLoader.Questions)
            {
                quizmasterGame.StartTimer(10);
                // Display question text and options
                Console.WriteLine($"Question: {question.QuestionText}");
                for (int i = 0; i < question.Options.Count; i++)
                {
                    Console.WriteLine($"Option {i + 1}: {question.Options[i]}");
                }

                var timerCts = new CancellationTokenSource();
                var timerTask = Task.Run(() =>
                    {
                        while (quizmasterGame.TimeLeft > 0 && !timerCts.Token.IsCancellationRequested)
                        {
                            Console.Write($"\n Time remaining: {quizmasterGame.TimeLeft} seconds   ");
                            Thread.Sleep(1020); // Wait for 1 second
                        }
                        if (quizmasterGame.TimeLeft <= 0)
                        {
                            Console.WriteLine("Time's up!                      ");
                        }
                    }, timerCts.Token);
                

                //Add functionality for checking answer
                System.Console.Write("Select an option: ");
                int selectedOption = 0;
                var input = Console.ReadLine();
                selectedOption = int.Parse(input!);
                timerCts.Cancel();

                if (quizmasterGame.CorrectAnswer(question.CorrectOption, selectedOption))
                {
                    quizmasterGame.AddPoint();
                    Console.WriteLine($"Correct answer is option {question.CorrectOption}: {question.Options[question.CorrectOption - 1]}");
                    System.Console.WriteLine($"You currently have {quizmasterGame.points} points!");

                }
                else
                {
                    Console.WriteLine($"Correct answer is option {question.CorrectOption}: {question.Options[question.CorrectOption - 1]}");
                    System.Console.WriteLine($"You currently have {quizmasterGame.points} Points!");
                }

                
                quizmasterGame.StopTimer();


                Console.WriteLine(); // Add a blank line for readability
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}