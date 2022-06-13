using System;

public class QuizQuestAnswers
{
    public long ID { get; set; } = 0;

    public long QuizID { get; set; } = 0;

    public int QuestNum { get; set; } = 0;

    public string Text { get; set; } = string.Empty;

    public bool IsRightAnswer { get; set; } = false;
}
