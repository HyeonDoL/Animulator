using UnityEngine;
using UnityEngine.UI;
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

    private float timer;

    [Header("UI Instances")]

    [SerializeField]
    private Text timerLabel;

    [SerializeField]
    private FoundTreasureUI foundTreasure;

    [SerializeField]
    private ResultUI result;


    private void Awake()
    {
        maxTreasureCount = 0;

        findTreasureCount = 0;

        timer = Debuger.playType == PlayType.Horror ? 300f : 500f;

        spawnList = new List<Transform>();

        instance = this;
    }

    private void Start()
    {
        UpdateTimeLabel(timer);

        if (Debuger.playType != PlayType.Normal)
            TreasureSpawn(Debuger.playType == PlayType.Horror ? 1 : 5);

        timerLabel.gameObject.SetActive(Debuger.playType != PlayType.Normal);
        foundTreasure.gameObject.SetActive(Debuger.playType != PlayType.Normal);
    }

    private void Update()
    {
        if (Debuger.playType != PlayType.Normal)
        {
            float oldTimer = timer;
            timer = timer - Time.deltaTime; //Mathf.Max(timer - Time.deltaTime, 0f);

            if (!(timer > 0f))
                result.ShowResult(GameResult.Failed);

            if (Mathf.CeilToInt(oldTimer) != Mathf.CeilToInt(timer))
                UpdateTimeLabel(Mathf.Max(timer));
        }
    }

    private void UpdateTimeLabel(float time)
    {
        timerLabel.text = string.Concat((time / 60f).ToString("00"), "m ", (time % 60f).ToString("00"), 's');
    }

    public void AddSpawnList(Transform spawn)
    {
        spawnList.Add(spawn);
    }

    public void TreasureSpawn(int treasureCount)
    {
        maxTreasureCount = treasureCount;
        foundTreasure.Initiallize(treasureCount);

        bool[] spawned = new bool[spawnList.Count];

        for (int i = 0; i < treasureCount; ++i)
        {
            Transform treasure = Instantiate<Transform>(treasurePrefab);

            int index;
            do
            {
                index = Random.Range(0, spawnList.Count);
            } while (spawned[index]);

            spawned[index] = true;
            Transform spawn = spawnList[index];
            treasure.localPosition = spawn.localPosition;
        }
    }

    public void TreasureFind()
    {
        findTreasureCount += 1;

        foundTreasure.SetFoundTreasureCount(findTreasureCount);

        if (findTreasureCount >= maxTreasureCount)
        {
            result.ShowResult(GameResult.Success);
        }
    }
}
