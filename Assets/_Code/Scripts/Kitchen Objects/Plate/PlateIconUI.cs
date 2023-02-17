using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconUI : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private Transform template;


    private void Awake()
    {
        template.gameObject.SetActive(false);
    }

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += PlateKitchenObjectOnOnIngredientAdded;
    }

    private void PlateKitchenObjectOnOnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (Transform chield in transform)
        {
            if (chield == template) continue;
            
            Destroy(chield.gameObject);
        }
        
        foreach (var obj in plateKitchenObject)
        {
            var itemTransform = Instantiate(template, transform);
            itemTransform.gameObject.SetActive(true);
            itemTransform.GetComponent<PlateIconSingleUI>().SetKitchenObjectSO(obj);
        }
    }
}
