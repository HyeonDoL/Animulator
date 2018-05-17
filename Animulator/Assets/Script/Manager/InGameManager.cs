using UnityEngine;
using System.Collections.Generic;

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

    [SerializeField]
    private PlayerDataContainer playerDataContainer;

    [SerializeField]
    private Transform treasurePrefab;

    private List<Transform> spawnList;

    public PlayerDataContainer PlayerDataContainer { get { return playerDataContainer; } }

    private int maxTreasureCount;

    private int findTreasureCount;

    private void Awake()
    {
        maxTreasureCount = 0;

        findTreasureCount = 0;

        spawnList = new List<Transform>();

        instance = this;
    }

    private void Start()
    {
        
    }

    public void AddSpawnList(Transform spawn)
    {
        spawnList.Add(spawn);
    }

    public void TreasureSpawn(int treasureCount)
    {
        maxTreasureCount = treasureCount;

        for(int i = 0; i < treasureCount; ++i)
        {
            Transform treasure = Instantiate<Transform>(treasurePrefab);

            Transform spawn = spawnList[Random.Range(0, spawnList.Count)];

            treasure.position = spawn.position;
            treasure.rotation = spawn.rotation;
            treasure.localScale = Vector3.one;
        }
    }

    public void TreasureFind()
    {
        findTreasureCount += 1;

        if(findTreasureCount >= maxTreasureCount)
        {
            // Game Clear!
        }
    }
}
