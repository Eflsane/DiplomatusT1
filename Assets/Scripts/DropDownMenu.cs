using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownMenu : MonoBehaviour
{
    [SerializeField] private GameObject object0;
    [SerializeField] private GameObject object1;
    [SerializeField] private GameObject object2;
    [SerializeField] private GameObject object3;
    [SerializeField] private GameObject object4;
    [SerializeField] private GameObject object5;
    [SerializeField] private GameObject object6;
    [SerializeField] private GameObject object7;
    [SerializeField] private GameObject object8;
    [SerializeField] private GameObject button0;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject button4;
    [SerializeField] private GameObject button5;
    [SerializeField] private GameObject button6;
    [SerializeField] private GameObject button7;
    [SerializeField] private GameObject button8;


    public void InputMenu(int value)
    {
        if (value == 0)
        {
            object0.SetActive(true);
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(false);
            object4.SetActive(false);
            object5.SetActive(false);
            object6.SetActive(false);
            object7.SetActive(false);
            object8.SetActive(false);
            button0.SetActive(true);
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            button5.SetActive(false);
            button6.SetActive(false);
            button7.SetActive(false);
            button8.SetActive(false);
        }
        else if (value == 1)
        {
            object0.SetActive(false);
            object1.SetActive(true);
            object2.SetActive(false);
            object3.SetActive(false);
            object4.SetActive(false);
            object5.SetActive(false);
            object6.SetActive(false);
            object7.SetActive(false);
            object8.SetActive(false);
            button0.SetActive(false);
            button1.SetActive(true);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            button5.SetActive(false);
            button6.SetActive(false);
            button7.SetActive(false);
            button8.SetActive(false);
        }
        else if (value == 2)
        {
            object0.SetActive(false);
            object1.SetActive(false);
            object2.SetActive(true);
            object3.SetActive(false);
            object4.SetActive(false);
            object5.SetActive(false);
            object6.SetActive(false);
            object7.SetActive(false);
            object8.SetActive(false);
            button0.SetActive(false);
            button1.SetActive(false);
            button2.SetActive(true);
            button3.SetActive(false);
            button4.SetActive(false);
            button5.SetActive(false);
            button6.SetActive(false);
            button7.SetActive(false);
            button8.SetActive(false);
        }
        else if (value == 3)
        {
            object0.SetActive(false);
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(true);
            object4.SetActive(false);
            object5.SetActive(false);
            object6.SetActive(false);
            object7.SetActive(false);
            object8.SetActive(false);
            button0.SetActive(false);
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(true);
            button4.SetActive(false);
            button5.SetActive(false);
            button6.SetActive(false);
            button7.SetActive(false);
            button8.SetActive(false);
        }
        else if (value == 4)
        {
            object0.SetActive(false);
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(false);
            object4.SetActive(true);
            object5.SetActive(false);
            object6.SetActive(false);
            object7.SetActive(false);
            object8.SetActive(false);
            button0.SetActive(false);
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(true);
            button5.SetActive(false);
            button6.SetActive(false);
            button7.SetActive(false);
            button8.SetActive(false);
        }
        else if (value == 5)
        {
            object0.SetActive(false);
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(false);
            object4.SetActive(false);
            object5.SetActive(true);
            object6.SetActive(false);
            object7.SetActive(false);
            object8.SetActive(false);
            button0.SetActive(false);
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            button5.SetActive(true);
            button6.SetActive(false);
            button7.SetActive(false);
            button8.SetActive(false);
        }
        else if (value == 6)
        {
            object0.SetActive(false);
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(false);
            object4.SetActive(false);
            object5.SetActive(false);
            object6.SetActive(true);
            object7.SetActive(false);
            object8.SetActive(false);
            button0.SetActive(false);
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            button5.SetActive(false);
            button6.SetActive(true);
            button7.SetActive(false);
            button8.SetActive(false);
        }
        else if (value == 7)
        {
            object0.SetActive(false);
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(false);
            object4.SetActive(false);
            object5.SetActive(false);
            object6.SetActive(false);
            object7.SetActive(true);
            object8.SetActive(false);
            button0.SetActive(false);
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            button5.SetActive(false);
            button6.SetActive(false);
            button7.SetActive(true);
            button8.SetActive(false);
        }
        else 
        {
            object0.SetActive(false);
            object1.SetActive(false);
            object2.SetActive(false);
            object3.SetActive(false);
            object4.SetActive(false);
            object5.SetActive(false);
            object6.SetActive(false);
            object7.SetActive(false);
            object8.SetActive(true);
            button0.SetActive(false);
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
            button4.SetActive(false);
            button5.SetActive(false);
            button6.SetActive(false);
            button7.SetActive(false);
            button8.SetActive(true);
        }
    }

}
