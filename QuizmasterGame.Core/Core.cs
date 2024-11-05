
namespace QuizmasterGame.Core;
using System.Timers;

public class QuizmasterGame(string word)
{
    public int TimeLeft {get; private set;} = 10;

    public static string SelectQuestion(string[] questions)
    {
        Random rand = new Random();
        int index = rand.Next(questions.Length);
        return questions[index];
    }

    public int Timer(int time)
    {
        Timer timer = new Timer(1000);

        return TimeLeft;
    }
}
