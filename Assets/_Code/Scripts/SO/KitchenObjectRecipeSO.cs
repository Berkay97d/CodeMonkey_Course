using UnityEngine;


[CreateAssetMenu(fileName = "New Kitchen Object Stat", menuName = "Stat/New Kitchen Object Recipe Stat")]
public class KitchenObjectRecipeSO : ScriptableObject
{
    [SerializeField] private KitchenObjectSO input;
    public KitchenObjectSO Input => input;

    [SerializeField] private KitchenObjectSO output;
    public KitchenObjectSO Output => output;

    [SerializeField] private int cuttingCount;
    public int CuttingCount => cuttingCount;

}
