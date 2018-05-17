using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void Awake()
    {
        InGameManager.Instance.AddSpawnList(this.transform);
    }
}
