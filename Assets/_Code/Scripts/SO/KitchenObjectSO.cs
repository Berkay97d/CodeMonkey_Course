using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Kitchen Object Stat", menuName = "Stat/New Kitchen Object Stat")]
public class KitchenObjectSO : ScriptableObject
{
    [SerializeField] private Transform prefab;
    public Transform Prefab => prefab;

    [SerializeField] private Sprite sprite;
    public Sprite Sprite => sprite;
    
    [SerializeField] private string objectName;
    public string ObjectName => objectName;


}
