using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuClicks : MonoBehaviour
{
    
    public GameObject infoPanel;

    public GameObject menuPanel;

    readonly string worldSelected = "WorldSelected";


    public void InfoPanelOpen()
    {
        if (infoPanel != null && menuPanel != null)
        {
            menuPanel.SetActive(false);
            infoPanel.SetActive(true);
        }
    }


    public void InfoPanelClose()
    {
        if (infoPanel != null && menuPanel != null)
        {
            menuPanel.SetActive(true);
            infoPanel.SetActive(false);
        }
    }

    public void AbstractMusicEnabler()
    {
        GameObject.Find("SceneMaster").GetComponent<SceneMasterScript>().MusicToggle();
    }

    public void LoadGameScene()
    {
        int WorldInt = PlayerPrefs.GetInt(worldSelected, 0);

        if (Time.timeScale < 1)
        {
            Time.timeScale = 1;
        }

        if (WorldInt == 0)
        {
            PlayerPrefs.SetInt(worldSelected, 1);
            SceneManager.LoadScene("Desert_Scene");
        }
        else
        {
          if (WorldInt == 1)
            {
              SceneManager.LoadScene("Desert_Scene");
                }
            else if (WorldInt == 2)
              {
                SceneManager.LoadScene("Snow_Scene");
                  }
        }
    }


    public void WorldSelect()
    {
        GameObject.Find("WorldSelectorObj").GetComponent<WorldSelector>().WorldSelectSet(gameObject.name);
    }

}
