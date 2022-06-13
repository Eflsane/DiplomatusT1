using System;


public class UserQuizStats
{
    public string Username { get; set; } = string.Empty;

    public long QuizID { get; set; } = 0;

    public DateTime BeginTime { get; set; }

    public DateTime EndTime { get; set; }

    public int UserScore { get; set; } = 0;
}
