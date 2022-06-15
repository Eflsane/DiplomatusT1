using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CallPieChartSex : MonoBehaviour
{
    [SerializeField]
    private PiePart piePart;

    private List<UsersWithout> users;
    private List<Genders> genders;

    public string dataURL = string.Empty;
    public string paramsURL = string.Empty;

    public event Action OnDataGeted;
    public event Action OnParamsGeted;

    private void Start()
    {
        /*OnDataGeted += GetParams;
        OnParamsGeted += GeneratePieChartValues;*/

        GetData();
    }

    /*private void GetData()
    {
        Debug.Log("startGettingUsrData");
        StartCoroutine(GetDataCoroutine());
    }

    private IEnumerator GetDataCoroutine()
    {

        UnityWebRequest request = new UnityWebRequest(dataURL, "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        List<UsersWithout> usersWithout = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UsersWithout>>(request.downloadHandler.text);
        Debug.Log(usersWithout[0].RegisterDate);

        users = usersWithout;

        OnDataGeted?.Invoke();
    }

    private void GetParams()
    {
        Debug.Log("startGettingParams");
        StartCoroutine(GetParamsCoroutine());
    }

    private IEnumerator GetParamsCoroutine()
    {

        UnityWebRequest request = new UnityWebRequest(paramsURL, "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("ParamsGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endParamsGet:" + request.responseCode.ToString());

        List<Genders> genders = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Genders>>(request.downloadHandler.text);
        Debug.Log(genders[0].Gender);

        this.genders = genders;

        OnParamsGeted?.Invoke();
    }*/

    public void GetData()
    {
        /*UsersWithoutDTO.Instance.OnGetAllUsersSuccess += GetAllUsers;
        GendersDTO.Instance.OnGetAllGendersSuccess += GetAllGenders;

        UsersWithoutDTO.Instance.GetAllUsers();*/

        /*transform.parent.parent.parent.
            GetComponentInChildren<CallChartAgeSexController>().OnDataUsersGetted += GetAllUsers;
        transform.parent.parent.parent.
            GetComponentInChildren<CallChartAgeSexController>().OnDataGendersGetted += GetAllGenders;*/

        CallChartAgeSexController.Instance.OnDataUsersGetted += GetAllUsers;
        CallChartAgeSexController.Instance.OnDataGendersGetted += GetAllGenders;
    }

    public void GetAllUsers(List<UsersWithout> usersWithout)
    {
        this.users = usersWithout;
        
        /*UsersWithoutDTO.Instance.OnGetAllUsersSuccess -= GetAllUsers;

        GendersDTO.Instance.GetAllGenders();*/
    }

    public void GetAllGenders(List<Genders> genders)
    {
        this.genders = genders;

        //GendersDTO.Instance.OnGetAllGendersSuccess -= GetAllGenders;

        GeneratePieChartValues();
    }

    public void GeneratePieChartValues()
    {
        SortedDictionary<long, float> charts = new SortedDictionary<long, float>();

        foreach(var gender in genders)
        {
            charts.Add(gender.Id - 1, 0);
        }

        foreach(var user in users)
        {
            charts[user.Gender - 1] += 1;
        }

        string[] agenda = new string[genders.Count];
        for(int i = 0; i < agenda.Length; i++)
        {
            if(genders[i].Gender.Contains("Female"))
                agenda[i] = "Женский";
            else
                agenda[i] = "Мужской";
        }

        var pieChart = GetComponentInParent<PieChart>();
        pieChart.DisplayNewValues(charts, pieChart.ImagePieParts, agenda);
        //GetComponent<PiePartContainer>().GeneratePieChartParts(charts);
    }
}
