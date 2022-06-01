using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopRegButton : MonoBehaviour
{
    [SerializeField]
    Button regButton;
    [SerializeField]
    GameObject regPanel;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LoginTopButtons>().OnTopRegisterButtonClick += TopRegButton_OnTopRegisterButtonClick;
        GetComponent<LoginTopButtons>().OnTopLoginButtonClick += TopRegButton_OnTopLoginButtonClick;
    }

    private void TopRegButton_OnTopRegisterButtonClick()
    {
        regButton.interactable = false;
        regPanel.SetActive(true);
    }

    private void TopRegButton_OnTopLoginButtonClick()
    {
        regButton.interactable = true;
        regPanel.SetActive(false);
        Debug.Log("LoginButtonClicked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
