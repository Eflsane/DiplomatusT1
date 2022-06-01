using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddButton : MonoBehaviour
{
    [SerializeField]
    GameObject addPanel;
    [SerializeField]
    Button addButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TopButtons>().OnDiagramsButtonClick += DiagramsButton_OnOtherButtonClick;
        GetComponent<TopButtons>().OnAddButtonClick += AddButton_OnAddButtonClick;
        GetComponent<TopButtons>().OnOptionsButtonClick += DiagramsButton_OnOtherButtonClick;
        GetComponent<TopButtons>().OnAdminButtonClick += DiagramsButton_OnOtherButtonClick;
    }

    private void AddButton_OnAddButtonClick()
    {
        addPanel.SetActive(true);
        addButton.interactable = false;

        Button[] addButtons = addPanel.transform.GetChild(0).GetComponentsInChildren<Button>();
        GameObject add = addPanel.transform.GetChild(1).gameObject;
        for (int i = 0; i < addButtons.Length; i++)
        {  
            addButtons[i].interactable = true;
            add.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void DiagramsButton_OnOtherButtonClick()
    {
        addPanel.SetActive(false);
        addButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
