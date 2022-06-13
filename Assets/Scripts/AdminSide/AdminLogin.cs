using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft;
using System;
using UnityEngine.SceneManagement;

public class AdminLogin : MonoBehaviour
{
    [SerializeField]
    private AdminLoginButton _adminLoginButton;
    [SerializeField]
    private string url = string.Empty;
    [SerializeField]
    private TMPro.TMP_InputField _usernameInput;
    [SerializeField]
    private TMPro.TMP_InputField _passwordInput;

    private string s = "CosmopediaAAngString";

    public event Action OnLogin = () => { };

    // Start is called before the first frame update
    void Start()
    {
        _adminLoginButton.OnLogin += AdminLoginButton_OnLogin;

        AdminsLoginDTO.Instance.OnLogAdminSuccess += AdminsLogin;
    }

    private void AdminLoginButton_OnLogin()
    {
        Debug.Log("startLogin");

        Debug.Log("input " + _usernameInput.text);
        Admins admin = new Admins()
        {
            AdminName = _usernameInput.text,
            Password = _passwordInput.text
        };

        Debug.Log(admin.LastLoginDate);

        AdminsLoginDTO.Instance.AdminLogin(admin);
    }

    private void AdminsLogin(AdminsWithout adminsWithout)
    {
        PlayerPrefs.SetString(s, adminsWithout.AdminName);
        PlayerPrefs.Save();

        Debug.Log(adminsWithout.LastLoginDate);

        SceneManager.LoadScene(8);
    }
}
