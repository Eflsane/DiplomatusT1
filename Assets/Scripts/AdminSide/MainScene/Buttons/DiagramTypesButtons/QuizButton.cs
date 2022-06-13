using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizButton : MonoBehaviour
{
    [SerializeField]
    GameObject quizPanel;
    [SerializeField]
    Button quizButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<DiagramTypesButtons>().OnBasicButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnAgeSexButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnUserButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnMinigameButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnMaterialButtonClick += OnOtherButtonClick;
        GetComponent<DiagramTypesButtons>().OnQuizButtonClick += QuizButton_OnQuizButtonClick;
    }

    private void QuizButton_OnQuizButtonClick()
    {
        quizPanel.SetActive(true);
        quizButton.interactable = false;

        CallQuizController.Instance.GetData();
    }
    private void OnOtherButtonClick()
    {
        quizPanel.SetActive(false);
        quizButton.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
