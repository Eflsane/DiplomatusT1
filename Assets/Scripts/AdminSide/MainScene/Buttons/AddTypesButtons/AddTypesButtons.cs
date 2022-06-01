﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTypesButtons : MonoBehaviour
{
    public event Action OnMinigameButtonClick = () => { };
    public event Action OnMaterialsButtonClick = () => { };

    public void MinigamesButtonClick()
    {
        OnMinigameButtonClick?.Invoke();
    }
    public void MaterialButtonClick()
    {
        OnMaterialsButtonClick?.Invoke();
    }
}
