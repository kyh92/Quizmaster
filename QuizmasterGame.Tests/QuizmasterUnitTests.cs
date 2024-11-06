using Shouldly;

namespace QuizmasterGame.Tests;

public class QuizmasterUnitTests
{

    [Fact]
    public void RandomQuestions()
    {
        //Arrange
        string[] Questions = ["Det här är en fråga 1", "Det här är en fråga 2", "Det här är en fråga 3"];
        //Act
        var selectedQuestion = Core.QuizmasterGame.SelectQuestion(Questions);
        //Assert
        Questions.ShouldContain(selectedQuestion);
    }

    [Fact]
    public void CorrectAnswer()
    {
        //Arrange
        var game = new Core.QuizmasterGame("sample question");
        int correctOption = 0;
        int selectedOption = 0;

        //Act
        var test = game.CorrectAnswer(correctOption, selectedOption);

        //Assert
        test.ShouldBeTrue();
    }

    [Fact]
    public void IncorrectAnswer()
    {
        //Arrange
        var game = new Core.QuizmasterGame("sample question");
        int correctOption = 0;
        int selectedOption = 1;

        //Act
        var test = game.CorrectAnswer(correctOption, selectedOption);

        //Assert
        test.ShouldBeFalse();
    }

    [Fact]
    public void LoadFromList()
    {
        string filepath = "questions.json";


    }
 
    [Fact]
    public void GetPoints()
    {

    }

    [Fact]
    public void MinusPoints()
    {

    }

    [Fact]
    public void ReadFromFile()
    {

    }

    [Fact]
    public void FailMissingFile()
    {

    }

    [Fact]
    public void TimerGoingDownByOne()
    {
        //Arrange
        var game = new Core.QuizmasterGame("sample question");
        int initialTime = game.TimeLeft;
        //Act
        game.OnTimedEvent(null, null);
        //Assert
        game.TimeLeft.ShouldBeEquivalentTo(--initialTime);
    }

    [Fact]
    public void TimeOut()
    {

    }

}