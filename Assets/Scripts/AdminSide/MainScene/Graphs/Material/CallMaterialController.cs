using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMaterialController : MonoBehaviour
{
    public static CallMaterialController Instance { get; private set; }

    public event Action<List<Materials>> OnDataMaterialsGetted = (List<Materials> materials) => { };
    public event Action<List<UsersWithout>> OnDataUsersGetted = (List<UsersWithout> usersWithout) => { };
    public event Action<List<Genders>> OnDataGendersGetted = (List<Genders> genders) => { };
    public event Action<List<UserOpennedMaterial>> OnDataUserOpennedMaterialsByMaterialGetted = (List<UserOpennedMaterial> userOpennedMaterials) => { };
    public event Action OnDataMaterialsUpdated = () => { };

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
        MaterialsDTO.Instance.OnGetAllMaterialsSuccess += GetAllMaterials;
        UsersWithoutDTO.Instance.OnGetAllUsersSuccess += GetAllUsers;
        GendersDTO.Instance.OnGetAllGendersSuccess += GetAllGenders;

        MaterialsDTO.Instance.GetAllMaterials();
    }

    public void GetAllMaterials(List<Materials> materials)
    {
        OnDataMaterialsGetted?.Invoke(materials);

        MaterialsDTO.Instance.OnGetAllMaterialsSuccess -= GetAllMaterials;

        UsersWithoutDTO.Instance.GetAllUsers();
    }

    public void GetAllUsers(List<UsersWithout> usersWithout)
    {
        OnDataUsersGetted?.Invoke(usersWithout);

        UsersWithoutDTO.Instance.OnGetAllUsersSuccess -= GetAllUsers;

        GendersDTO.Instance.GetAllGenders();
    }

    public void GetAllGenders(List<Genders> genders)
    {
        OnDataGendersGetted?.Invoke(genders);

        GendersDTO.Instance.OnGetAllGendersSuccess -= GetAllGenders;
    }

    public void GetUserOpennedMaterialsByMaterialData(long id)
    {
        UserOpennedMaterialDTO.Instance.OnGetUserOpennedMaterialsByMaterialSuccess += GetUserOpennedMaterialsByMaterial;

        UserOpennedMaterialDTO.Instance.GetUserOpennedMaterialsByMaterial(id);
    }

    public void GetUserOpennedMaterialsByMaterial(List<UserOpennedMaterial> userOpennedMaterial)
    {
        OnDataUserOpennedMaterialsByMaterialGetted?.Invoke(userOpennedMaterial);

        UserOpennedMaterialDTO.Instance.OnGetUserOpennedMaterialsByMaterialSuccess -= GetUserOpennedMaterialsByMaterial;
    }

    public void UpdateMaterialsData(Materials material)
    {
        MaterialsDTO.Instance.OnUpdateMaterialSuccess += UpdateMaterials;

        MaterialsDTO.Instance.UpdateMaterial(material);
    }

    public void UpdateMaterials()
    {
        OnDataMaterialsUpdated?.Invoke();

        MaterialsDTO.Instance.OnUpdateMaterialSuccess -= UpdateMaterials;
    }
}
