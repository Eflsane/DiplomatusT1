using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiagramsButton : MonoBehaviour
{
    [SerializeField]
    GameObject diagramsPanel;
    [SerializeField]
    Button diagramsButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TopButtons>().OnDiagramsButtonClick += DiagramsButton_OnDiagramsButtonClick;
        GetComponent<TopButtons>().OnAddButtonClick += DiagramsButton_OnOtherButtonClick;
        GetComponent<TopButtons>().OnOptionsButtonClick += DiagramsButton_OnOtherButtonClick;
        GetComponent<TopButtons>().OnAdminButtonClick += DiagramsButton_OnOtherButtonClick;
    }

    private void DiagramsButton_OnDiagramsButtonClick()
    {
        diagramsPanel.SetActive(true);
        diagramsButton.interactable = false;

        Button[] diagramsButtons = diagramsPanel.transform.GetChild(0).GetComponentsInChildren<Button>();
        GameObject diagrams = diagramsPanel.transform.GetChild(1).gameObject;
        for(int i = 0; i < diagramsButtons.Length; i++)
        {
            diagramsButtons[i].interactable = true;
            diagrams.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void DiagramsButton_OnOtherButtonClick()
    {
        diagramsPanel.SetActive(false);
        diagramsButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
