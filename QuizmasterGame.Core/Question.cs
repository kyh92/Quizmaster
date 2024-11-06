namespace QuizmasterGame.Core;
public record Question(string QuestionText, List<string> Options, int CorrectOption);