namespace QuizmasterGame.ConsoleApp;
using QuizmasterGame.Core;

internal class Program
{
    private static void Main(string[] args)
    {
        string relativePath = @"..\data\questions.json";
        string fullPath = Path.GetFullPath(relativePath);

        System.Console.WriteLine($"Full path to questions.json {fullPath}");

        try
        {
            // Load questions using JsonQuestionLoader
            var questionLoader = new JsonQuestionLoader(fullPath);
            var questions = questionLoader.Questions;

            // Create an instance of QuizmasterGame
            var quizmasterGame = new QuizmasterGame("Quiz Game");

            // Use the Questions property to access the loaded questions
            foreach (var question in questionLoader.Questions)
            {
                // Display question text and options
                Console.WriteLine($"Question: {question.QuestionText}");
                for (int i = 0; i < question.Options.Count; i++)
                {
                    Console.WriteLine($"Option {i + 1}: {question.Options[i]}");
                }
                Console.WriteLine($"Correct Option: {question.CorrectOption + 1}");
                Console.WriteLine(); // Add a blank line for readability
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}