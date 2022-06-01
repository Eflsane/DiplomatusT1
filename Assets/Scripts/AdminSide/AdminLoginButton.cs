using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminLoginButton : MonoBehaviour
{
    public event Action OnLogin = () => { };
    public event Action OnReg = () => { };

    public TMPro.TMP_InputField _usernameInput;

    public void Login()
    {
        Debug.Log("log");
        OnLogin?.Invoke();
    }

    public void Register()
    {
        Debug.Log("reg");
        OnReg?.Invoke();
    }
}
