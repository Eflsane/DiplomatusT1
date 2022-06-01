using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrolBG : MonoBehaviour
{
    public float speed;
    public float tileSize;
    private Transform obj;
    
    // Start is called before the first frame update
    void Start()
    {
        obj = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        obj.position = new Vector3(obj.position.x, Mathf.Repeat(Time.time * speed, tileSize), obj.position.z);
    }
}
