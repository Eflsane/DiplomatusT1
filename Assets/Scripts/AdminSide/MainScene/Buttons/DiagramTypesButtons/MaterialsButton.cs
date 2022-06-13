using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialsButton : MonoBehaviour
{
    [SerializeField]
    GameObject materialPanel;
    [SerializeField]
    Button materialButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DiagramTypesButtons>().OnBasicButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnAgeSexButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnUserButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnMinigameButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnMaterialButtonClick += MaterialsButton_OnMaterialButtonClick;
        GetComponent<DiagramTypesButtons>().OnQuizButtonClick += OnOtherButtonClick;
    }

    private void MaterialsButton_OnMaterialButtonClick()
    {
        materialPanel.SetActive(true);
        materialButton.interactable = false;

        CallMaterialController.Instance.GetData();
    }
    private void OnOtherButtonClick()
    {
        materialPanel.SetActive(false);
        materialButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
