using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials
{
    public Materials() { }

    public Materials(long id, string name, string description, int scoreToUnlock, DateTime creationDate)
    {
        Id = id;
        this.Name = name ?? throw new ArgumentNullException(nameof(name));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        ScoreToUnlock = scoreToUnlock;
        CreationDate = creationDate;
    }

    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int ScoreToUnlock { get; set; }

    public DateTime CreationDate { get; set; }
}
