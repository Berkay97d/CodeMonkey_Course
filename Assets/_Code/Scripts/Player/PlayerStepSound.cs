
using UnityEngine;

public class PlayerStepSound : MonoBehaviour
{
    [SerializeField] private Player player;
    
    
    private void FixedUpdate()
    {
        if (player.IsWalking())
        {
            SoundManager.Instance.PlayPlayerStep();
        }
    }
}
