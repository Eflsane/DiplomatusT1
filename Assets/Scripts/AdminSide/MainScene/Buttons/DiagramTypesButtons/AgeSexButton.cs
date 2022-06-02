using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgeSexButton : MonoBehaviour
{
    [SerializeField]
    GameObject asPanel;
    [SerializeField]
    Button asButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DiagramTypesButtons>().OnBasicButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnAgeSexButtonClick += ASButton_OnBasicButtonClick;
        GetComponent<DiagramTypesButtons>().OnUserButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnMinigameButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnMaterialButtonClick += OnOtherButtonClick;
    }

    private void ASButton_OnBasicButtonClick()
    {
        asPanel.SetActive(true);
        asButton.interactable = false;

        CallChartAgeSexController.Instance.GetData();
    }

    private void OnOtherButtonClick()
    {
        asPanel.SetActive(false);
        asButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
