using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAddMaterialController : MonoBehaviour
{
    public static CallAddMaterialController Instance { get; private set; }

    public event Action OnDataMaterialsAdd = () => { };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
    }

    private void Start()
    {
        GetData();
    }

    public void GetData()
    {

    }

    public void AddMaterialsData(Materials material)
    {
        MaterialsDTO.Instance.OnAddMaterialSuccess += AddMaterial;

        MaterialsDTO.Instance.AddMaterial(material);
    }

    public void AddMaterial()
    {
        OnDataMaterialsAdd?.Invoke();

        MaterialsDTO.Instance.OnAddMaterialSuccess -= AddMaterial;
    }
}
