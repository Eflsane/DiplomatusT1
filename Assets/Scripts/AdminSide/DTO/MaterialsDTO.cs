using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class MaterialsDTO : MonoBehaviour
{
    public static MaterialsDTO Instance { get; private set; }

    public string dataURL = string.Empty;

    public event Action<List<Materials>> OnGetAllMaterialsSuccess = (List<Materials> dbMaterials) => { };
    public event Action<Materials> OnGetMaterialSuccess = (Materials dbMaterials) => { };
    public event Action OnUpdateMaterialSuccess = () => { };
    public event Action OnAddMaterialSuccess = () => { };
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

    public void GetAllMaterials()
    {
        Debug.Log("startGettingMaterialsData");
        StartCoroutine(GetAllMaterialsCoroutine());
    }

    private IEnumerator GetAllMaterialsCoroutine()
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

        List<Materials> materials = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Materials>>(request.downloadHandler.text);
        Debug.Log(materials[0].Name);

        OnGetAllMaterialsSuccess?.Invoke(materials);
    }

    public void GetMaterial(long id)
    {
        Debug.Log("startGettingMaterialsData");
        StartCoroutine(GetMaterialCoroutine(id));
    }

    private IEnumerator GetMaterialCoroutine(long id)
    {
        UnityWebRequest request = new UnityWebRequest($"{dataURL}/{id}", "get");
        request.SetRequestHeader("Content-Type", "application/json");
        request.downloadHandler = new DownloadHandlerBuffer();

        yield return request.SendWebRequest();
        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log("DataGetMess:" + request.error);
            yield break;
        }

        Debug.Log("endDataGet:" + request.responseCode.ToString());

        Materials material = Newtonsoft.Json.JsonConvert.DeserializeObject<Materials>(request.downloadHandler.text);
        Debug.Log(material.Name);

        OnGetMaterialSuccess?.Invoke(material);
    }

    public void UpdateMaterial(Materials material)
    {
        Debug.Log("startEditingMaterialsData");
        StartCoroutine(UpdateMaterialCoroutine(material));
    }

    private IEnumerator UpdateMaterialCoroutine(Materials material)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(material);
        byte[] bytesIn = Encoding.UTF8.GetBytes(input);

        UnityWebRequest request = new UnityWebRequest($"{dataURL}/update/{material.Id}", "put");
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

        OnUpdateMaterialSuccess?.Invoke();
    }

    public void AddMaterial(Materials material)
    {
        Debug.Log("startAddMaterialsData");
        StartCoroutine(AddMaterialCoroutine(material));
    }

    private IEnumerator AddMaterialCoroutine(Materials material)
    {
        string input = Newtonsoft.Json.JsonConvert.SerializeObject(material);
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

        OnAddMaterialSuccess?.Invoke();
    }
}
