using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TopButtons>().OnExitButtonClick += ExitButton_OnExitButtonClick;
    }

    private void ExitButton_OnExitButtonClick()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
