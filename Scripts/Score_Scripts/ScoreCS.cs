using UnityEngine;
using TMPro;

public class ScoreCS : MonoBehaviour
{

    private float score;
    private int hi_score;

    // will use this to track score increment !
    private int localLevel = 1;

    //use this to stop incrementing on max level
    private bool isMax = false;

    // this to save to user prefs !
    readonly string highScoreKey = "HighScore";

    private float scoreMultiplier = 1.0f;
    //public Text scoreText;

    TextMeshProUGUI scoreText;

    WorldController lvl_manager;
    // HiScoreCS hi_Score_agent;


    // will use this for scorepop !

    public float GetScoreMulti()
    {
        return scoreMultiplier;
    }

    public void RaiseScore()
    {
        this.score += scoreMultiplier;
        float localScore = this.score;

        SetCurrentScore(localScore);
        if (isMax is false)
        {
            if ((int)localScore > 5 && localLevel < 2) //12
            {
                lvl_manager.LevelShift(2);
                this.scoreMultiplier += 0.5f;
                this.localLevel++;
            }
            else if ((int)localScore > 10 && localLevel < 3) // 25
            {
                lvl_manager.LevelShift(3);
                this.scoreMultiplier += 0.25f;
                this.localLevel++;
            }
            else if ((int)localScore > 25 && localLevel < 4) // 45
            {
                lvl_manager.LevelShift(4);
                this.scoreMultiplier += 0.25f;
                this.localLevel++;
            }
            else if ((int)localScore > 55 && localLevel < 5) // 60
            {
                lvl_manager.LevelShift(5);
                this.scoreMultiplier += 0.25f;
                this.localLevel++;
            }
            else if ((int)localScore > 75 && localLevel < 6) // 70
            {
                lvl_manager.LevelShift(5);
                this.scoreMultiplier += 0.25f;
                this.localLevel++;
                isMax = true;
            }
        }

    }
    
    public void SetHiScore()
    {
        if (score > this.hi_score)
        {
            PlayerPrefs.SetInt(highScoreKey, (int)score);
        }

    }

    private void Awake()
    {
        hi_score = PlayerPrefs.GetInt(highScoreKey, 0);
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        lvl_manager = GameObject.Find("MainController").GetComponent<WorldController>();
    }


    public void SetCurrentScore(float localScore)
    {
        this.scoreText.text = "Score : " + localScore;
    }


    public float GetCurrentScore()
    {
        return (float)this.score;
    }

}
