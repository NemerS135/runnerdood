using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class PanelButtons : MonoBehaviour
{
    public GameObject panelObject;
    
    public GameObject pauseButton;



    public void AbstractClosePanel()
    {
        if (panelObject != null)
        {
            panelObject.SetActive(false);
        }
    }



    public void AbstractOpenPanel()
    {
        if(panelObject != null)
        {
            panelObject.SetActive(true);
        }
    }




    public void AbstractMusicEnabler()
    {
        GameObject.Find("MusicMaster").GetComponent<MusicCS>().MusicToggle();
    }



    public void BackToMenu()
    {
        Time.timeScale = 1f;
        Thread.Sleep(500);
        SceneManager.LoadScene("MainMenu_Scene");
    }


    
    public void OpenPauseMenu()
    {
        if(panelObject != null)
        {
            Time.timeScale = 0;
            if (panelObject != null && pauseButton != null)
            {
                panelObject.SetActive(true);
                pauseButton.SetActive(false);
            }
        }
    }



    public void ClosePauseMenu()
    {
        if (panelObject != null && pauseButton != null)
        {
            pauseButton.SetActive(true);
            panelObject.SetActive(false);
        }
        Time.timeScale = 1;
    }



    public void ScoreReseter()
    {
        string highScoreKey = "HighScore";
        int newHiScore = PlayerPrefs.GetInt(highScoreKey, 0);
        GameObject.Find("HighScoreComp")
            .GetComponent<HiScoreCS>()
            .SetHighScore(newHiScore);
    }
    
}
