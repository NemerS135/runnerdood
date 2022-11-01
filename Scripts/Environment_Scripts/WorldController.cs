using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WorldController : MonoBehaviour
{
    private bool isGameOver = false;
    
    MainCubeCS cubeObj;
    TerrainGen terrainGen;
    BackgroundCS backGround;
    PlayerController player;
    ScoreCS scoreObj;
    ScoreColliderCS SC_col;
    public GameObject GM_Canvas;
    public GameObject pauseButton;

    GoogleAdMobController googleController;

    // these for cnotrolling watched an ads and reward +1 lives
    private bool hasWatchedAdsBool;


    // this to control number of times to spawn !
    private int lives = 1;
    public float level = 1;


    public void StartWatchingAd()
    {
        if (isGameOver && !hasWatchedAdsBool)
        {
            googleController.ShowRewardedAd();
        }
        else if (hasWatchedAdsBool)
        {
            GameObject.Find("AdsTextComponent").GetComponent<Text>().text = "Reward Already Received !";
        }
    }


    public void DoneRewardedAds()
    {
        GameObject.Find("AdsTextComponent").GetComponent<Text>().text = "New Life +1    (b^_^)b";
        
        this.hasWatchedAdsBool = true;

        ReviveLives();

    }


    public void SetNoAdsAvaiable()
    {
        GameObject.Find("AdsTextComponent").GetComponent<Text>().text = "No Ads Available :(";
    }

    public void ReviveLives()
    {
        this.lives += 1;

        GameObject.Find("LiveCount").GetComponent<LiveCountCS>().SetLiveCount(lives);

        // now re-enable play button !
        GameObject.Find("Button_play").GetComponent<GameOverMenu>().EnablePlayButton();
    }
    

    public int GetLives()
    {
        return this.lives;
    }

    public float GetLevel()
    {
        return this.level;
    }



    private void Awake()
    {
        // GameOver panel canvas !
        GM_Canvas.SetActive(false);

        //init hearts !
        this.lives = 1;

        //init level
        this.level = 1;

        // bool to stop redundancy on GameOverWorld()
        isGameOver = false;

        // Init Game object references !
        cubeObj = GameObject.Find("MotherCube").GetComponent<MainCubeCS>();
        terrainGen = GameObject.Find("TerrainMaster").GetComponent<TerrainGen>();
        backGround = GameObject.Find("backGroundQuad").GetComponent<BackgroundCS>();

        // Init Game object references !
        player = GameObject.Find("player1").GetComponent<PlayerController>();
        scoreObj = GameObject.Find("ScoreComponent").GetComponent<ScoreCS>();
        SC_col = GameObject.Find("ScoreCubeCol").GetComponent<ScoreColliderCS>();

        googleController = GameObject.Find("GoogleAdMobController").GetComponent<GoogleAdMobController>();

    }

    public void LevelShift(float level)
    {
        switch(level)
        {
            case (int)2:
                {
                    backGround.SetSpeed(2);
                    terrainGen.TerrainSpeeder(2);
                    cubeObj.SetSpawnFreq(2);
                    SC_col.SetScoreMulti(0.5f);
                    this.level = 2;

                    player.AnimSpeed(2);
                }
                break;

            case (int)3:
                {
                    backGround.SetSpeed(3);
                    terrainGen.TerrainSpeeder(3);
                    cubeObj.SetSpawnFreq(3);
                    SC_col.SetScoreMulti(0.25f);
                    this.level = 3;

                    player.AnimSpeed(3);
                }
                break;

            case (int)4:
                {
                    backGround.SetSpeed(4);
                    terrainGen.TerrainSpeeder(4);
                    cubeObj.SetSpawnFreq(4);
                    SC_col.SetScoreMulti(0.25f);
                    this.level = 4;

                    player.AnimSpeed(4);
                }
                break;

            case (int)5:
                {
                    backGround.SetSpeed(5);
                    terrainGen.TerrainSpeeder(5);
                    cubeObj.SetSpawnFreq(5);
                    SC_col.SetScoreMulti(0.25f);
                    this.level = 5;

                    player.AnimSpeed(5);
                }
                break;
            case (int)6:
                {
                    cubeObj.SetSpawnFreq(6);
                    this.level = 6;
                }
                break;
        }
    }

    public void GameOverWorld()
    {
        
      terrainGen.SetGameOver(true, false);

      backGround.SetSpeed(0);

      cubeObj.FreezeCubes();

      // check and set new Hi-score
      scoreObj.SetHiScore();

        if (isGameOver is false)
        {
            this.lives -= 1;

            if(this.lives < 1)
            {
                GameObject.Find("LiveCount").GetComponent<LiveCountCS>().SetLiveCount(lives);
            }

            isGameOver = true;

            RestartWorldInit();

        }
        
    }


    protected void RestartWorldInit()
    {
        GM_Canvas.SetActive(true);
        pauseButton.SetActive(false);

        if(this.lives < 1)
        {  // hide play button !
            GameObject.Find("Button_play").GetComponent<GameOverMenu>().KillPlayButton();
        }
    }
    

    public void RestartWorldAction(float level)
    {
        if (!(this.lives < 1) && player.gameObject.activeInHierarchy is false)
        {
            // hide the pause panel !
            GM_Canvas.SetActive(false);



            // reset the tornado location and null the velocity !
            GameObject.Find("Tor_master").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            GameObject.Find("Tor_master").GetComponent<Transform>().position = new Vector3(6f, 2.45f, 153f);

            // make terrain check if is Over and Restarted : to re-start the speed !
            terrainGen.SetGameOver(false, true);
            terrainGen.GameOverCheck((int)level);


            // destroy cubes and re-start Invoke(spawn)
            cubeObj.RestartCubes((int)level);


            // re-set speed to last level
            backGround.SetSpeed((int)level);


            // re-set player positions 
            player.gameObject.SetActive(true);
            player.RespawnPlayer((int)level);
            

            // set new hi-score
            scoreObj.SetHiScore();

            // reset gameOver bool !
            isGameOver = false;

            // reset pause button to active
            pauseButton.SetActive(true);
            
        }
    }


    public void ResetWorld()
    {
        scoreObj.SetHiScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
