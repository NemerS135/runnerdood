using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{

    WorldController WrldCtrl;
    
    float WorldLevel = 1;
    private int lives = 1;

    void SetLives(int lives)
    {
        this.lives = lives;
    }
    
    public void GO_Continue()
    {
        WrldCtrl = GameObject.Find("MainController").GetComponent<WorldController>();

        WorldLevel = WrldCtrl.GetLevel();

        WrldCtrl.RestartWorldAction(WorldLevel);
    }


    // kill or enable play button
    public void KillPlayButton()
    {
        gameObject.GetComponent<Button>().interactable = false;
    }

    public void EnablePlayButton()
    {
        gameObject.GetComponent<Button>().interactable = true;
    }



    public void TryWatchAds()
    {
        GameObject.Find("MainController").GetComponent<WorldController>().StartWatchingAd();
    }

    

    public void GO_Restart()
    {
        WrldCtrl.ResetWorld();
    }

    private void Start()
    {
        WrldCtrl = GameObject.Find("MainController").GetComponent<WorldController>();
        SetLives(WrldCtrl.GetLives());
    }
}
