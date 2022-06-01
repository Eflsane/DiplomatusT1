using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutAddMinigames : MonoBehaviour
{
    [SerializeField]
    private List<TMPro.TMP_InputField> paramsList = new List<TMPro.TMP_InputField>();

    public List<TMPro.TMP_InputField> ParamsList { get => paramsList; private set => paramsList = value; }

    // Start is called before the first frame update
    void Start()
    {
        LoadMinigames();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadMinigames()
    {
        //Добавить событие для получения ответа от контроллеров
    }

    public void AddMinigame()
    {
        Minigames minigame = new Minigames()
        {
            Name = ParamsList[0].text,
            ScoreToUnlock = int.Parse(ParamsList[1].text),
            Description = ParamsList[2].text
            
        };
        CallAddMinigameController.Instance.AddMinigamesData(minigame);
    }
}
