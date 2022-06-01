using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class UsersWithoutLoginDTO : MonoBehaviour
{
    public static UsersWithoutLoginDTO Instance { get; private set; }

    public string dataURL = string.Empty;

    public event Action<UsersWithout> OnLogUserSuccess = (UsersWithout dbUsersWithout) => { };
    public event Action<UsersWithout> OnRegUserSuccess = (UsersWithout dbUsersWithout) => { };
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UserLogin(Users user)
    {
        Debug.Log("startLogin");
        StartCoroutine(UserLoginCoroutine(user));
    }

    private IEnumerator UserLoginCoroutine(Users user)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(user);
        byte[] bytesIn = Encoding.UTF8.GetBytes(input);

        UnityWebRequest request = new UnityWebRequest(dataURL + "/login", "post");
        request.SetRequestHeader("Content-Type", "application/json");
        request.uploadHandler = new UploadHandlerRaw(bytesIn);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("LoginMess:" + request.error);
            yield break;
        }

        Debug.Log("endLogin:" + request.responseCode.ToString());

        UsersWithout loggedUser = Newtonsoft.Json.JsonConvert.DeserializeObject<UsersWithout>(request.downloadHandler.text);
        Debug.Log(loggedUser.LastLoginDate);

        OnLogUserSuccess?.Invoke(loggedUser);
    }

    public void UserReg(Users user)
    {
        Debug.Log("startLogin");
        StartCoroutine(UserRegCoroutine(user));
    }

    private IEnumerator UserRegCoroutine(Users user)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(user);
        byte[] bytesIn = Encoding.UTF8.GetBytes(input);

        UnityWebRequest request = new UnityWebRequest(dataURL + "/add", "post");
        request.SetRequestHeader("Content-Type", "application/json");
        request.uploadHandler = new UploadHandlerRaw(bytesIn);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("LoginMess:" + request.error);
            yield break;
        }

        Debug.Log("endLogin:" + request.responseCode.ToString());

        UsersWithout loggedUser = Newtonsoft.Json.JsonConvert.DeserializeObject<UsersWithout>(request.downloadHandler.text);
        Debug.Log(loggedUser.LastLoginDate);

        OnRegUserSuccess?.Invoke(loggedUser);
    }
}
