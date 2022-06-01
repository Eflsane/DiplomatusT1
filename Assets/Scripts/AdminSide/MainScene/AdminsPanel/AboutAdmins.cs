using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AboutAdmins : MonoBehaviour
{
    [SerializeField]
    private List<TMPro.TextMeshProUGUI> paramsList = new List<TMPro.TextMeshProUGUI>();

    private AdminsWithout adminsWithout;

    public List<TextMeshProUGUI> ParamsList { get => paramsList; private set => paramsList = value; }

    public AdminsWithout AdminsWithout { get => adminsWithout; private set => adminsWithout = value; }


    // Start is called before the first frame update
    void Start()
    {
        LoadAdmins();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetAdmin(AdminsWithout adminsWithout)
    {
        this.AdminsWithout = adminsWithout;

        SetAdminData();
    }

    private void SetAdminData()
    {
        ParamsList[0].text = adminsWithout.AdminName;
        ParamsList[1].text = adminsWithout.RegisterDate.ToString();
        
    }

    public void LoadAdmins()
    {
        CallAdminController.Instance.OnDataAdminGetted += GetAdmin;
    }
}
