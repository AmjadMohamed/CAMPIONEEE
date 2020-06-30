using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour
{
    // public variables
    public float MovementSpeed = 1.0f;

    // private variables
     


    void Update()
    {
        transform.Translate(Vector3.right * MovementSpeed * Time.deltaTime, Space.Self);    
    }
}
