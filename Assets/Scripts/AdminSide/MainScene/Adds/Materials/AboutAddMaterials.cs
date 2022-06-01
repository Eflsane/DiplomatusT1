using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutAddMaterials : MonoBehaviour
{
    [SerializeField]
    private List<TMPro.TMP_InputField> paramsList = new List<TMPro.TMP_InputField>();

    public List<TMPro.TMP_InputField> ParamsList { get => paramsList; private set => paramsList = value; }

    // Start is called before the first frame update
    void Start()
    {
        LoadMaterils();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMaterils()
    {
        //Добавить событие для получения ответа от контроллеров
    }

    public void AddMaterial()
    {
        Materials material = new Materials()
        {
            Name = ParamsList[0].text,
            ScoreToUnlock = int.Parse(ParamsList[1].text),
            Description = ParamsList[2].text

        };
        CallAddMaterialController.Instance.AddMaterialsData(material);
    }
}
