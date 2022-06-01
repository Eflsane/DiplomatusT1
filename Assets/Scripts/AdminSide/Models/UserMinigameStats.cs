using System;

public class UserMinigameStats
{
    public string Username { get; set; } = string.Empty;
    public long MinigameId { get; set; }
    public DateTime BeginTime { get; set; }
    public DateTime EndTime { get; set; }
    public double UserScore { get; set; }
}
