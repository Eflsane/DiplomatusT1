using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMaterialButton : MonoBehaviour
{
    [SerializeField]
    GameObject addMaterialPanel;
    [SerializeField]
    Button addMaterialButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AddTypesButtons>().OnMinigameButtonClick += OnOtherButtonClick;
        GetComponent<AddTypesButtons>().OnMaterialsButtonClick += AddMaterialButton_OnBasicButtonClick;
    }

    private void AddMaterialButton_OnBasicButtonClick()
    {
        addMaterialPanel.SetActive(true);
        addMaterialButton.interactable = false;
    }

    private void OnOtherButtonClick()
    {
        addMaterialPanel.SetActive(false);
        addMaterialButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
