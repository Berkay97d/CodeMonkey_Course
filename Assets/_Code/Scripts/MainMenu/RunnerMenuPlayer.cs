using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerMenuPlayer : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private int runTime;
    
    private float time;
    
    
    private void FixedUpdate()
    {
        time += Time.deltaTime;

        if ((int)(time / runTime) % 2 == 0)
        {
            Debug.Log("yOK");
            transform.Translate(Vector3.forward * speed);
        }
        else
        {
            Debug.Log("VAR");
            transform.Translate(Vector3.back * speed);
            
        }
    }
}
