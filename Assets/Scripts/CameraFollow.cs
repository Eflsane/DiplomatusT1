using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _object; //An object camera will follow
    [SerializeField] private Vector3 _distanceFromObject; // Camera's distance from the object
    void LateUpdate()
    {
        Vector3 positionToGo = _object.transform.position + _distanceFromObject; //Target position of the camera
        Vector3 smoothPosition = Vector3.Lerp(a: transform.position, b: positionToGo, t: 0.125F); 
        transform.position = smoothPosition;
    }
}

