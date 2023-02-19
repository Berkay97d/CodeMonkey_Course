using UnityEngine;


[CreateAssetMenu(fileName = "New Kitchen Object Stat", menuName = "Stat/New Frying Object Recipe Stat")]
public class FryingRecipeSO : ScriptableObject
{
    [SerializeField] private KitchenObjectSO input;
    public KitchenObjectSO Input => input;

    [SerializeField] private KitchenObjectSO output;
    public KitchenObjectSO Output => output;

    [SerializeField] private float fryingTimerMax;
    public float FryingTimerMax => fryingTimerMax;

}