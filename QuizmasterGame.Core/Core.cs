namespace QuizmasterGame.Core;

using System.Timers;
using System.Text.Json;

public class QuizmasterGame(string word)
{
    private Timer _timer;
    public int TimeLeft { get; private set; } = 10;
    public int points { get; private set; } = 0;

    public static string SelectQuestion(string[] questions)
    {
        Random rand = new Random();
        int index = rand.Next(questions.Length);
        return questions[index];
    }


    public IEnumerable<Question> LoadQuestions(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var questions = JsonSerializer.Deserialize<List<Question>>(json);

        return questions!;
    }

    public Boolean CorrectAnswer(int correctOption, int selectedOption)
    {
        if (selectedOption == correctOption)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void AddPoint()
    {
        points++;
    }

    public void StartTimer(int time)
    {
        TimeLeft = time;
        _timer = new Timer(1000);
        _timer.Elapsed += OnTimedEvent!;
        _timer.AutoReset = true;
        _timer.Enabled = true;
    }

    public void StopTimer()
    {
        _timer.Stop();
        _timer.Dispose();
    }

    public void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        if (TimeLeft >= 0)
        {
            TimeLeft--;
        }
        else
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
}

