using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayType
{
    Normal,
    Horror,
    Treasure
}

public class MainMenu : MonoBehaviour {
    
    public void StartGame(int playType)
    {
        Debuger.playType = (PlayType)playType;
        SceneManager.LoadScene(1);
    }
}
