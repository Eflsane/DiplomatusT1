using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class AdminsLoginDTO : MonoBehaviour
{
    public static AdminsLoginDTO Instance { get; private set; }

    public string dataURL = string.Empty;

    public event Action<AdminsWithout> OnLogAdminSuccess = (AdminsWithout dbAdminsWithout) => { };
    public event Action<AdminsWithout> OnRegAdminSuccess = (AdminsWithout dbAdminsWithout) => { };
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

    public void AdminLogin(Admins admin)
    {
        Debug.Log("startLogin");
        StartCoroutine(AdminLoginCoroutine(admin));
    }

    private IEnumerator AdminLoginCoroutine(Admins admin)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(admin);
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

        AdminsWithout loggedAdmin = Newtonsoft.Json.JsonConvert.DeserializeObject<AdminsWithout>(request.downloadHandler.text);
        Debug.Log(loggedAdmin.LastLoginDate);

        OnLogAdminSuccess?.Invoke(loggedAdmin);
        /*admin.RegisterDate = loggedAdmin.RegisterDate;
        AdminLoginTimeUpdate(admin);

        request = new UnityWebRequest(url + "/" + admin.AdminName, "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("GetLoginMess:" + request.error);
        }

        Debug.Log("endLogin:" + request.responseCode.ToString());

        loggedAdmin = Newtonsoft.Json.JsonConvert.DeserializeObject<AdminsWithout>(request.downloadHandler.text);
        Debug.Log(loggedAdmin.LastLoginDate);*/
    }

    /*private void AdminLoginTimeUpdate(Admins admin)
    {

        StartCoroutine(TimeUpdateCoroutine(admin));


    }

    private IEnumerator TimeUpdateCoroutine(Admins admin)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(admin);
        byte[] bytesIn = Encoding.UTF8.GetBytes(input);

        Debug.Log(input);

        UnityWebRequest request = new UnityWebRequest(url + "/update/" + admin.AdminName + "/" + true, "put");
        request.SetRequestHeader("Content-Type", "application/json");
        request.uploadHandler = new UploadHandlerRaw(bytesIn);
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("UpdateLoginMess:" + request.error);
        }

        Debug.Log("endLogin:" + request.responseCode.ToString());
    }*/

    public void AdminReg(Admins admin)
    {
        Debug.Log("startLogin");
        StartCoroutine(AdminRegCoroutine(admin));
    }

    private IEnumerator AdminRegCoroutine(Admins admin)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(admin);
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

        AdminsWithout loggedAdmin = Newtonsoft.Json.JsonConvert.DeserializeObject<AdminsWithout>(request.downloadHandler.text);
        Debug.Log(loggedAdmin.LastLoginDate);

        OnRegAdminSuccess?.Invoke(loggedAdmin);
    }
}
