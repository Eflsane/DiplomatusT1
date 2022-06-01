using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Genders
{
    public Genders() { }

    public Genders(long id, string gender)
    {
        Id = id;
        Gender = gender ?? throw new ArgumentNullException(nameof(gender));
    }

    public long Id { get; set; }
    public string Gender { get; set; } = string.Empty;
}
