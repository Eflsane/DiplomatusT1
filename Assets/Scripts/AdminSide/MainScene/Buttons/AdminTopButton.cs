using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminTopButton : MonoBehaviour
{
    [SerializeField]
    GameObject adminPanel;
    [SerializeField]
    Button adminButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TopButtons>().OnDiagramsButtonClick += DiagramsButton_OnOtherButtonClick;
        GetComponent<TopButtons>().OnAddButtonClick += DiagramsButton_OnOtherButtonClick;
        GetComponent<TopButtons>().OnOptionsButtonClick += DiagramsButton_OnOtherButtonClick;
        GetComponent<TopButtons>().OnAdminButtonClick += AdminTopButton_OnAdminButtonClick;
    }

    private void AdminTopButton_OnAdminButtonClick()
    {
        adminPanel.SetActive(true);
        adminButton.interactable = false;

        CallAdminController.Instance.GetData(AdminDataManager.Instance.AName);
    }

    private void DiagramsButton_OnOtherButtonClick()
    {
        adminPanel.SetActive(false);
        adminButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
