using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAdminController : MonoBehaviour
{
    public static CallAdminController Instance { get; private set; }

    public event Action<AdminsWithout> OnDataAdminGetted = (AdminsWithout adminsWithout) => { };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
    }

    private void Start()
    {
        //GetData();
    }

    public void GetData(string adminName)
    {
        AdminsDTO.Instance.OnGetAdminSuccess += GetAdmin;

        AdminsDTO.Instance.GetAdmin(adminName);
    }

    public void GetAdmin(AdminsWithout adminsWithout)
    {
        AdminsDTO.Instance.OnGetAdminSuccess -= GetAdmin;

        OnDataAdminGetted?.Invoke(adminsWithout);
    }
}
