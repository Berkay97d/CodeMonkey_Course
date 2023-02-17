using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct MatchGameobjectWithSO
    {
        public KitchenObjectSO KitchenObjectSO;
        public GameObject gameObj;
    }
    
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<MatchGameobjectWithSO> mathingList;
    
    
    
    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObjectOnOnIngredientAdded;
        
        foreach (var element in mathingList)
        {
            element.gameObj.SetActive(false);
        }
    }

    private void PlateKitchenObjectOnOnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (var element in mathingList)
        {
            if (element.KitchenObjectSO == e.AddedSO)
            {
                element.gameObj.SetActive(true);
            }
        }
    }
}
