using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameButton : MonoBehaviour
{
    [SerializeField]
    GameObject minigamePanel;
    [SerializeField]
    Button minigameButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DiagramTypesButtons>().OnBasicButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnAgeSexButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnUserButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnMinigameButtonClick += MinigameButton_OnBasicButtonClick;
    }

    private void MinigameButton_OnBasicButtonClick()
    {
        minigamePanel.SetActive(true);
        minigameButton.interactable = false;

        CallMinigameController.Instance.GetData();
    }

    private void OnOtherButtonClick()
    {
        minigamePanel.SetActive(false);
        minigameButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
