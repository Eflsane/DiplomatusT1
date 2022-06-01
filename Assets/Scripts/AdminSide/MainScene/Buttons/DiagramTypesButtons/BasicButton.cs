using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicButton : MonoBehaviour
{
    [SerializeField]
    GameObject basicPanel;
    [SerializeField]
    Button basicButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DiagramTypesButtons>().OnBasicButtonClick += BasicButton_OnBasicButtonClick;
        GetComponent<DiagramTypesButtons>().OnAgeSexButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnUserButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnMinigameButtonClick += OnOtherButtonClick;
    }

    private void BasicButton_OnBasicButtonClick()
    {
        basicPanel.SetActive(true);
        basicButton.interactable = false;

        CallBasicController.Instance.GetData();
    }

    private void OnOtherButtonClick()
    {
        basicPanel.SetActive(false);
        basicButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
