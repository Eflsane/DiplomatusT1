using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddQuizlButton : MonoBehaviour
{
    [SerializeField]
    GameObject addQuizPanel;
    [SerializeField]
    Button addQuizButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AddTypesButtons>().OnMinigameButtonClick += OnOtherButtonClick;
        GetComponent<AddTypesButtons>().OnMaterialsButtonClick += OnOtherButtonClick;
        GetComponent<AddTypesButtons>().OnQuizesButtonClick += AddQuizButton_OnBasicButtonClick;
    }

    private void AddQuizButton_OnBasicButtonClick()
    {
        addQuizPanel.SetActive(true);
        addQuizButton.interactable = false;
    }

    private void OnOtherButtonClick()
    {
        addQuizPanel.SetActive(false);
        addQuizButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
