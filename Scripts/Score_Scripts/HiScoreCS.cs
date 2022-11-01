using UnityEngine;
using TMPro;

public class HiScoreCS : MonoBehaviour
{
    TextMeshPro scoreText;

    // this to save to user prefs !
    readonly string highScoreKey = "HighScore";

    private int hi_score = 0;
    

    public void SetHighScore(int new_score)
    {
        scoreText.text = "Hi-Score : " + new_score;
    }


    private void Start()
    {
        scoreText = GetComponent<TextMeshPro>();
        hi_score = PlayerPrefs.GetInt(highScoreKey, 0);
        scoreText.text = "Hi-Score : " + hi_score;

    }


}
