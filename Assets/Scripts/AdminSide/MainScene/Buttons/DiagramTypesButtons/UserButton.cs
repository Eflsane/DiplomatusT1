using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserButton : MonoBehaviour
{
    [SerializeField]
    GameObject userPanel;
    [SerializeField]
    Button userButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DiagramTypesButtons>().OnBasicButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnAgeSexButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnUserButtonClick += UserButton_OnBasicButtonClick;
        GetComponent<DiagramTypesButtons>().OnMinigameButtonClick += OnOtherButtonClick;
    }

    private void UserButton_OnBasicButtonClick()
    {
        userPanel.SetActive(true);
        userButton.interactable = false;

        CallUserController.Instance.GetData();
    }

    private void OnOtherButtonClick()
    {
        userPanel.SetActive(false);
        userButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
