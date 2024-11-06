namespace QuizmasterGame.ConsoleApp;

using System.Runtime.InteropServices;
using QuizmasterGame.Core;

internal class Program
{
    private static void Main(string[] args)
    {
        string relativePath = @"..\data\questions.json";
        string fullPath = Path.GetFullPath(relativePath);

        Console.Clear();
        Console.SetBufferSize(Console.BufferWidth, 200);

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

                // Save the current cursor position to keep countdown on a single line
                int countdownLine = Console.CursorTop;

                // Display "Select an option:" on a fixed position
                Console.SetCursorPosition(0, countdownLine + 1);
                System.Console.Write("Select an option:   ");
                //
                var timerCts = new CancellationTokenSource();
                var timerTask = Task.Run(() =>
                    {
                        while (quizmasterGame.TimeLeft >= 0 && !timerCts.Token.IsCancellationRequested)
                        {
                            Console.SetCursorPosition(0, countdownLine);
                            Console.Write($"Time remaining: {quizmasterGame.TimeLeft} seconds           ");
                            Console.SetCursorPosition(18, countdownLine + 1);
                            Thread.Sleep(100); // Wait for 1 second                            
                        }
                        if (quizmasterGame.TimeLeft < 0)
                        {
                            Console.SetCursorPosition(0, countdownLine);
                            Console.WriteLine("Time's up!                                     ");
                            Console.SetCursorPosition(18, countdownLine + 1);
                        }
                    }, timerCts.Token);

                //Get user input for answer
                int selectedOption = 0;
                var input = Console.ReadLine();
                timerCts.Cancel();
                selectedOption = int.Parse(input!);

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