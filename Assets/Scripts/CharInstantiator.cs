using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInstantiator : MonoBehaviour
{
    // public variables
    public GameObject[] Characters;

    // private variables 
    private float TimeBetweenRespawns = 1f;

    private void Update()
    {
        TimeBetweenRespawns -= Time.deltaTime;
        if (TimeBetweenRespawns <= 0)
        {
            Instantiate(Characters[Random.Range(0, Characters.Length)], transform.position, Quaternion.identity);
            TimeBetweenRespawns = 1f;
        }

    }

    
}
