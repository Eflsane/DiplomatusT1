using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopButtons : MonoBehaviour
{
    public event Action OnDiagramsButtonClick = () => { };
    public event Action OnAddButtonClick = () => { };
    public event Action OnOptionsButtonClick = () => { };
    public event Action OnAdminButtonClick = () => { };
    public event Action OnExitButtonClick = () => { };

    public void DiagramsButtonClick()
    {
        OnDiagramsButtonClick?.Invoke();
    }
    public void AddButtonClick()
    {
        OnAddButtonClick?.Invoke();
    }
    public void OptionsButtonClick()
    {
        OnOptionsButtonClick?.Invoke();
    }
    public void AdminButtonClick()
    {
        OnAdminButtonClick?.Invoke();
    }
    public void ExitButtonClick()
    {
        OnExitButtonClick?.Invoke();
    }
}
