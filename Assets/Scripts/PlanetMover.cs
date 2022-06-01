using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMover : MonoBehaviour
{
    [SerializeField]
    Transform center;

    [SerializeField]
    float radius, angularSpeed;

    float positionX, positionY, angle; //= 0f;
    

    void Start()
    {
        //positionX = Random.value;
       // positionY = Random.value;
        angle = Random.value;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        positionX = center.position.x + Mathf.Cos(angle) * radius;
        positionY = center.position.y + Mathf.Sin(angle) * radius;
        transform.position = new Vector2(positionX, positionY) ;
        Vector3 smoothPosition = Vector3.Lerp(a: transform.position, b: transform.position, t: 1f);
        transform.position = smoothPosition;
        angle = angle + Time.deltaTime * angularSpeed;

        
    }
}
