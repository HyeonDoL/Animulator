using UnityEngine;

public class PlayerDataContainer : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private PlayerInteraction playerInteraction;

    public Transform Transform { get { return playerTransform; } }

    public PlayerInteraction PlayerInteraction { get { return playerInteraction; } }
}
