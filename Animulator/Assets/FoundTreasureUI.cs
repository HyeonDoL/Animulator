using UnityEngine;
using UnityEngine.UI;

public class FoundTreasureUI : MonoBehaviour {

    [SerializeField]
    private Image[] icons;

    [SerializeField]
    private Sprite found, unfound;

    public void Initiallize(int count)
    {
        for (int i = 0; i < icons.Length; i++)
            icons[i].gameObject.SetActive(i < count);
    }

    public void SetFoundTreasureCount(int count)
    {
        for (int i = 0; i < icons.Length; i++)
            icons[i].sprite = i < count ? found : unfound;
    }
}