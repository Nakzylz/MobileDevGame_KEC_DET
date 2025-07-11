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
    public GameObject controlPanel;
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Start()
    {
        /* Unpause the game if needed */
        Time.timeScale = 1;

        // check for a high score and set it to our TMProUGUI
        GetDisplayScore();

        // slide in the Panel with all the goodies
        SlideMenuIn(controlPanel);

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

    /// <summary>
    /// Will move an object from the left side of the screen
    /// to the center
    /// </summary>
    /// <param name="obj">The UI element we would like to
    /// move</param>
    public void SlideMenuIn(GameObject obj)
    {
        obj.SetActive(true);
        var rt = obj.GetComponent<RectTransform>();
        if (rt)
        {
            /* Set the object's position offscreen */
            var pos = rt.position;
            pos.x = -Screen.width / 2;
            rt.position = pos;
            /* Move the object to the center of the screen
               (x of 0 is centered) */
            var tween = LeanTween.moveX(rt, 0, 1.5f);
            tween.setEase(LeanTweenType.easeInOutExpo);
            tween.setIgnoreTimeScale(true);
        }
    }

    /// <summary>
    /// Will move an object to the right offscreen
    /// </summary>
    /// <param name="obj">The UI element we would like to
    /// move </param>
    public void SlideMenuOut(GameObject obj)
    {
        var rt = obj.GetComponent<RectTransform>();
        if (rt)
        {
            var tween = LeanTween.moveX(rt,
            Screen.width / 2, 0.5f);
            tween.setEase(LeanTweenType.easeOutQuad);
            tween.setIgnoreTimeScale(true);
            tween.setOnComplete(() =>
            {
                obj.SetActive(false);
            });
        }
    }
}
