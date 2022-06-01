using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopLoginButton : MonoBehaviour
{
    [SerializeField]
    Button loginButton;
    [SerializeField]
    GameObject loginPanel;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LoginTopButtons>().OnTopLoginButtonClick += TopLoginButton_OnTopLoginButtonClick;
        GetComponent<LoginTopButtons>().OnTopRegisterButtonClick += TopLoginButton_OnTopRegisterButtonClick;
    }

    private void TopLoginButton_OnTopLoginButtonClick()
    {
        loginButton.interactable = false;
        loginPanel.SetActive(true);
    }

    private void TopLoginButton_OnTopRegisterButtonClick()
    {
        loginButton.interactable = true;
        loginPanel.SetActive(false);
        Debug.Log("RegButtonClicked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
