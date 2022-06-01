using System;

public class Admins
{
    public Admins(){}

    public Admins(string adminName, string password, DateTime registerDate, DateTime lastLoginDate)
    {
        AdminName = adminName ?? throw new ArgumentNullException(nameof(adminName));
        Password = password ?? throw new ArgumentNullException(nameof(password));
        RegisterDate = registerDate;
        LastLoginDate = lastLoginDate;
    }

    public string AdminName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public DateTime RegisterDate { get; set; }

    public DateTime LastLoginDate { get; set; }
}
