using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] private float waitTime;
    private float time;
    
    private void Update()
    {
        if (time < waitTime)
        {
            time += Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }
}
