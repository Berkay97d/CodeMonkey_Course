
using System;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CuttingCounter cuttingCounter;
    
    
    private void Start()
    {
        cuttingCounter.OnPlayerCutObject += CuttingCounterOnOnPlayerCutObject;
    }

    private void CuttingCounterOnOnPlayerCutObject(object sender, EventArgs e)
    {
        animator.SetTrigger("Cut");
    }
}
