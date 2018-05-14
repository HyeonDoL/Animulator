using UnityEngine;

public class InGameManager : MonoBehaviour
{
    private static InGameManager instance;
    public static InGameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    [SerializeField]
    private PlayerDataContainer playerDataContainer;

    public PlayerDataContainer PlayerDataContainer { get { return playerDataContainer; } }
}
