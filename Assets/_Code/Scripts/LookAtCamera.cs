using System;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private new Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void LateUpdate()
    {
        transform.forward = camera.transform.forward;
    }
}
