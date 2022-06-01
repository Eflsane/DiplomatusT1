using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsButton : MonoBehaviour
{
    [SerializeField]
    GameObject optPanel;
    [SerializeField]
    Button optButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TopButtons>().OnDiagramsButtonClick += DiagramsButton_OnOtherButtonClick;
        GetComponent<TopButtons>().OnAddButtonClick += DiagramsButton_OnOtherButtonClick;
        GetComponent<TopButtons>().OnOptionsButtonClick += OptionsButton_OnOptionsButtonClick;
        GetComponent<TopButtons>().OnAdminButtonClick += DiagramsButton_OnOtherButtonClick;
    }

    private void OptionsButton_OnOptionsButtonClick()
    {
        optPanel.SetActive(true);
        optButton.interactable = false;

        Button[] optButtons = optPanel.transform.GetChild(0).GetComponentsInChildren<Button>();
        GameObject opt = optPanel.transform.GetChild(1).gameObject;
        for (int i = 0; i < optButtons.Length; i++)
        {
            optButtons[i].interactable = true;
            opt.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void DiagramsButton_OnOtherButtonClick()
    {
        //optPanel.SetActive(false);
        optButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
