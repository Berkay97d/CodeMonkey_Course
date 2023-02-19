using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Kitchen Object Stat", menuName = "Order/New Order")]
public class OrderItemSO : ScriptableObject
{
    [SerializeField] private KitchenObjectSO[] ingrediants;
    public KitchenObjectSO[] Ingrediants => ingrediants;

    [SerializeField] private string orderName;
    public string OrderName => orderName;


}
