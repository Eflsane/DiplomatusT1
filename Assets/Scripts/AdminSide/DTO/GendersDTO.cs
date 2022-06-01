using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GendersDTO : MonoBehaviour
{
    public static GendersDTO Instance { get; private set; }
    public string dataURL = string.Empty;

    public event Action<List<Genders>> OnGetAllGendersSuccess = (List<Genders> dbGenders) => { };
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

    public void GetAllGenders()
    {
        Debug.Log("startGettingParams");
        StartCoroutine(GetAllGendersCoroutine());
    }

    private IEnumerator GetAllGendersCoroutine()
    {

        UnityWebRequest request = new UnityWebRequest(dataURL, "get");
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

        OnGetAllGendersSuccess?.Invoke(genders);
    }
}
