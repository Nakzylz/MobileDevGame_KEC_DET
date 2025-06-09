using UnityEngine;
using UnityEngine.SceneManagement; // LoadScene
using TMPro;
public class MainMenuBehaviour : MonoBehaviour
{
    /// <summary>
    /// Will load a new scene upon being called
    /// </summary>
    /// <param name="levelName">The name of the level
    /// we want to go to</param>
    /// 
    public TextMeshProUGUI highScoreText;
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Start()
    {
        GetDisplayScore();
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("score", 0);
        GetDisplayScore();
    }

    private void GetDisplayScore()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("score").ToString();
    }
}
