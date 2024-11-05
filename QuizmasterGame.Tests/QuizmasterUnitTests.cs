using Shouldly;

namespace QuizmasterGame.Tests;

public class QuizmasterUnitTests
{
   
    [Fact]
    public void RandomQuestions()
    {
        //Fråga
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

    }

    [Fact]
    public void IncorrectAnswer()
    {

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
    public void TimeTimer()
    {   //Timer existerar och har tiden 10 sekunder

    //Arrange
    int time = 10000;
    var game = new Core.QuizmasterGame("apple");
    //Act
    var time2 = game.Timer(time);
    //Assert
       time.ShouldBeEquivalentTo(time2);
        
    }

    [Fact]
    public void TimeOut()
    {

    }    
    
}