using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsersWithout
{
    public UsersWithout() { }

    public UsersWithout(string username, string email, long gender, DateTime dateOfBirth, DateTime registerDate)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Gender = gender;
        DateOfBirth = dateOfBirth;
        RegisterDate = registerDate;
    }

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public long AvatarID { get; set; } = 0;

    public long Gender { get; set; } = 0;

    public DateTime DateOfBirth { get; set; }

    public DateTime RegisterDate { get; set; }

    public DateTime LastLoginDate { get; set; }

    public double Coinz { get; set; } = 0;
}
