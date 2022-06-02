using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class UserOpennedMaterialDTO : MonoBehaviour
{
    public static UserOpennedMaterialDTO Instance { get; private set; }

    public string dataURL = string.Empty;

    public event Action<List<UserOpennedMaterial>> OnGetAllUserOpennedMaterialsSuccess = (List<UserOpennedMaterial> dbUserOpennedMaterials) => { };
    public event Action<List<UserOpennedMaterial>> OnGetUserOpennedMaterialsByMaterialSuccess = (List<UserOpennedMaterial> dbUserOpennedMaterials) => { };
    public event Action<List<UserOpennedMaterial>> OnGetUserOpennedMaterialsByUserSuccess = (List<UserOpennedMaterial> dbUserOpennedMaterials) => { };
    public event Action<List<UserOpennedMaterial>> OnGetUserOpennedMaterialsByUserMaterialSuccess = (List<UserOpennedMaterial> dbUserOpennedMaterials) => { };
    public event Action OnAddUserOpennedMaterialSuccess = () => { };
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

    public void GetAllUserOpennedMaterials()
    {
        Debug.Log("startGettingMaterialsData");
        StartCoroutine(GetAllUserOpennedMaterialsCoroutine());
    }

    private IEnumerator GetAllUserOpennedMaterialsCoroutine()
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

        List<UserOpennedMaterial> userOpennedMaterials = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserOpennedMaterial>>(request.downloadHandler.text);
        Debug.Log(userOpennedMaterials[0].MaterialId);

        OnGetAllUserOpennedMaterialsSuccess?.Invoke(userOpennedMaterials);
    }

    public void GetUserOpennedMaterialsByMaterial(long id)
    {
        Debug.Log("startGettingMaterialsData");
        StartCoroutine(GetUserOpennedMaterialsByMaterialCoroutine(id));
    }

    private IEnumerator GetUserOpennedMaterialsByMaterialCoroutine(long id)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/Materials/{id}", "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        List<UserOpennedMaterial> userOpennedMaterials = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserOpennedMaterial>>(request.downloadHandler.text);
        Debug.Log(userOpennedMaterials[0].MaterialId);

        OnGetUserOpennedMaterialsByMaterialSuccess?.Invoke(userOpennedMaterials);
    }

    public void GetUserOpennedMaterialssByUser(string username)
    {
        Debug.Log("startGettingMaterialsData");
        StartCoroutine(GetUserOpennedMaterialsByUserCoroutine(username));
    }

    private IEnumerator GetUserOpennedMaterialsByUserCoroutine(string username)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/Users/{username}", "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        List<UserOpennedMaterial> userOpennedMaterials = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserOpennedMaterial>>(request.downloadHandler.text);
        Debug.Log(userOpennedMaterials[0].MaterialId);

        OnGetUserOpennedMaterialsByUserSuccess?.Invoke(userOpennedMaterials);
    }

    public void GetUserOpennedMaterialsByUserMaterial(string username, long id)
    {
        Debug.Log("startGettingMaterialsData");
        StartCoroutine(GetUserOpennedMaterialsByUserMaterialCoroutine(username, id));
    }

    private IEnumerator GetUserOpennedMaterialsByUserMaterialCoroutine(string username, long id)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/Users/{username}/materials/{id}", "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        List<UserOpennedMaterial> userOpennedMaterials = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserOpennedMaterial>>(request.downloadHandler.text);
        Debug.Log(userOpennedMaterials[0].MaterialId);

        OnGetUserOpennedMaterialsByUserMaterialSuccess?.Invoke(userOpennedMaterials);
    }

    public void AddUserOpennedMaterial(UserOpennedMaterial userOpennedMaterial)
    {
        Debug.Log("startAddMinigamesData");
        StartCoroutine(AddUserOpennedMaterialCoroutine(userOpennedMaterial));
    }

    private IEnumerator AddUserOpennedMaterialCoroutine(UserOpennedMaterial userOpennedMaterial)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(userOpennedMaterial);
        byte[] bytesIn = Encoding.UTF8.GetBytes(input);

        UnityWebRequest request = new UnityWebRequest($"{dataURL}/add", "post");
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

        //Minigames minigame = Newtonsoft.Json.JsonConvert.DeserializeObject<Minigames>(request.downloadHandler.text);
        //Debug.Log(minigame.Name);

        OnAddUserOpennedMaterialSuccess?.Invoke();
    }
}
