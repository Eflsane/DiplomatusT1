using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMinigameButton : MonoBehaviour
{
    [SerializeField]
    GameObject addMinigamePanel;
    [SerializeField]
    Button addMinigameButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AddTypesButtons>().OnMinigameButtonClick += AddMinigameButton_OnBasicButtonClick;
        GetComponent<AddTypesButtons>().OnMaterialsButtonClick += OnOtherButtonClick;
    }

    private void AddMinigameButton_OnBasicButtonClick()
    {
        addMinigamePanel.SetActive(true);
        addMinigameButton.interactable = false;
    }

    private void OnOtherButtonClick()
    {
        addMinigamePanel.SetActive(false);
        addMinigameButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
