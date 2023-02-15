using System;
using UnityEngine;

public class TrashCounterVisual : MonoBehaviour
{
    [SerializeField] private Animator[] animator;
    [SerializeField] private TrashCounter trashCounter;

    private void Start()
    {
        trashCounter.OnPlayerInteractWithTrash += TrashCounterOnOnPlayerInteractWithTrash;
    }

    private void TrashCounterOnOnPlayerInteractWithTrash(object sender, EventArgs e)
    {
        foreach (var VARIABLE in animator)
        {
            VARIABLE.SetTrigger("Trash");
        }
    }
}
