using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserWithGender
{
    public UserWithGender() { }

    public UserWithGender(string username, string email, string gender, DateTime dateOfBirth, DateTime registerDate)
    {
        Username = username ?? throw new ArgumentNullException(nameof(username));
        Email = email ?? throw new ArgumentNullException(nameof(email));
        Gender = gender ?? throw new ArgumentNullException(nameof(gender));
        DateOfBirth = dateOfBirth;
        RegisterDate = registerDate;
    }

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public long AvatarID { get; set; } = 0;

    public string Gender { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    public DateTime RegisterDate { get; set; }

    public DateTime LastLoginDate { get; set; }

    public double Coinz { get; set; } = 0;
}
