using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Users
{
    public Users() { }

    public Users(string username, string password, string email, long gender, DateTime dateOfBirth, DateTime registerDate)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
        Password = password ?? throw new ArgumentNullException(nameof(password));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Gender = gender;
        DateOfBirth = dateOfBirth;
        RegisterDate = registerDate;
    }

    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public long AvatarID { get; set; } = 0;

    public long Gender { get; set; } = 0;

    public DateTime DateOfBirth { get; set; }

    public DateTime RegisterDate { get; set; }

    public DateTime LastLoginDate { get; set; }

    public double Coinz { get; set; } = 0;
}
