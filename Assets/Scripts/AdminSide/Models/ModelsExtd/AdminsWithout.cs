using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminsWithout
{
    public AdminsWithout (){}

    public AdminsWithout(string adminname, DateTime registerDate, DateTime lastLoginDate)
    {
        AdminName = adminname ?? throw new ArgumentNullException(nameof(adminname));
        RegisterDate = registerDate;
        LastLoginDate = lastLoginDate;
    }

    public string AdminName { get; set; } = string.Empty;

    public DateTime RegisterDate { get; set; }

    public DateTime LastLoginDate { get; set; }
}
