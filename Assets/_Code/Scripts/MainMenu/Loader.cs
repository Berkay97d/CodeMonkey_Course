using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] private float maxWaitTime;
    private float time;
    
    private void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(2);
        }
        
        if (time < maxWaitTime)
        {
            time += Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
