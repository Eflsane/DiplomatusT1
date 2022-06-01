using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation1 : MonoBehaviour
{
    [SerializeField]
    public float speed1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed1 * Time.deltaTime, speed1 * Time.deltaTime, speed1 * Time.deltaTime, Space.Self);
    }
}
