using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class UsersWithoutDTO : MonoBehaviour
{
    public static UsersWithoutDTO Instance { get; private set; }

    public string dataURL = string.Empty;

    public event Action<List<UsersWithout>> OnGetAllUsersSuccess = (List<UsersWithout> dbUsersWithout) => { };
    public event Action<UsersWithout> OnGetUserSuccess = (UsersWithout dbUsersWithout) => { };
    public event Action OnGUpdateCoinzSuccess = () => { };
   
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null) 
            Instance = this;
        else if(Instance == this)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetAllUsers()
    {
        Debug.Log("startGettingUsrData");
        StartCoroutine(GetAllUsersCoroutine());
    }

    private IEnumerator GetAllUsersCoroutine()
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

        OnGetAllUsersSuccess?.Invoke(usersWithout);
    }

    public void GetUser(string username)
    {
        Debug.Log("startGettingUsrData");
        StartCoroutine(GetUserCoroutine(username));
    }

    private IEnumerator GetUserCoroutine(string username)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/{username}", "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        UsersWithout usersWithout = Newtonsoft.Json.JsonConvert.DeserializeObject<UsersWithout>(request.downloadHandler.text);
        Debug.Log(usersWithout.RegisterDate);

        OnGetUserSuccess?.Invoke(usersWithout);
    }

    public void UpdateUserCoinz(UsersWithout user)
    {
        Debug.Log("startGettingUsrData");
        StartCoroutine(UpdateUserCoinzCoroutine(user));
    }

    private IEnumerator UpdateUserCoinzCoroutine(UsersWithout user)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(user);
        byte[] bytesIn = Encoding.UTF8.GetBytes(input);

        UnityWebRequest request = new UnityWebRequest($"{dataURL}/update/CCC/{user.Username}", "put");
        request.SetRequestHeader("Content-Type", "application/json");
        request.uploadHandler = new UploadHandlerRaw(bytesIn);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        //UsersWithout usersWithout = Newtonsoft.Json.JsonConvert.DeserializeObject<UsersWithout>(request.downloadHandler.text);
        //sDebug.Log(usersWithout.RegisterDate);

        OnGUpdateCoinzSuccess?.Invoke();
    }
}
