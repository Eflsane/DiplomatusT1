using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagramTypesButtons : MonoBehaviour
{
    public event Action OnBasicButtonClick = () => { };
    public event Action OnAgeSexButtonClick = () => { };
    public event Action OnUserButtonClick = () => { };
    public event Action OnMinigameButtonClick = () => { };
    public event Action OnMaterialButtonClick = () => { };

    public void BasicButtonClick()
    {
        OnBasicButtonClick?.Invoke();
    }
    public void AgeSexButtonClick()
    {
        OnAgeSexButtonClick?.Invoke();
    }
    public void UserButtonClick()
    {
        OnUserButtonClick?.Invoke();
    }
    public void MinigameButtonClick()
    {
        OnMinigameButtonClick?.Invoke();
    }

    public void MaterialButtonClick()
    {
        OnMaterialButtonClick?.Invoke();
    }
}
