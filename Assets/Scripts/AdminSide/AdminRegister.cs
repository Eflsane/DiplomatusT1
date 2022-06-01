using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminRegister : MonoBehaviour
{
    [SerializeField]
    private AdminLoginButton _adminRegisterButton;
    [SerializeField]
    private string url = string.Empty;
    [SerializeField]
    private TMPro.TMP_InputField _usernameInput;
    [SerializeField]
    private TMPro.TMP_InputField _passwordInput;

    private string s = "CosmopediaAAngString";

    public event Action OnRegister = () => { };

    // Start is called before the first frame update
    void Start()
    {
        _adminRegisterButton.OnReg += AdminLoginButton_OnRegister;

        AdminsLoginDTO.Instance.OnRegAdminSuccess += AdminsReg;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AdminLoginButton_OnRegister()
    {
        Debug.Log("startReg");

        Debug.Log(_usernameInput.text);
        Admins admin = new Admins()
        {
            AdminName = _usernameInput.text,
            Password = _passwordInput.text
        };

        Debug.Log(admin.LastLoginDate);

        AdminsLoginDTO.Instance.AdminReg(admin);
    }

    private void AdminsReg(AdminsWithout adminsWithout)
    {
        PlayerPrefs.SetString(s, adminsWithout.AdminName);
        PlayerPrefs.Save();

        Debug.Log(adminsWithout.LastLoginDate);

        SceneManager.LoadScene(1);
    }
}
