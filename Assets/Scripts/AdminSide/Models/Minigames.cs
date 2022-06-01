using System;
using System.Collections;
using System.Collections.Generic;

public class Minigames
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int ScoreToUnlock { get; set; }

    public DateTime CreationDate { get; set; }
}
