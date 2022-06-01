using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginTopButtons : MonoBehaviour
{
    public event Action OnTopRegisterButtonClick = () => { };
    public event Action OnTopLoginButtonClick = () => { };

    public void TopRegisterButtonClick()
    {
        OnTopRegisterButtonClick?.Invoke();
    }
    public void TopLoginButtonClick()
    {
        OnTopLoginButtonClick?.Invoke();
    }
}
