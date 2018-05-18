using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameResult
{
    Success,
    Failed,
}

public class ResultUI : MonoBehaviour {

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Text resultLabel;

    private void Awake()
    {
        target.SetActive(false);
    }

    public void ShowResult(GameResult result)
    {
        if (!target.activeInHierarchy)
        {
            target.SetActive(true);

            resultLabel.text = result == GameResult.Success ? "GAME CLEAR!" : "GAME OVER";
        }
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
