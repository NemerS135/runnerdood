using UnityEngine;
using TMPro;

public class HiScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;

    // this to save to user prefs !
    readonly string highScoreKey = "HighScore";

    int hi_score = 0;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

        this.hi_score = PlayerPrefs.GetInt(highScoreKey, 0);
        this.scoreText.text = "Hi-Score : " + hi_score;

    }
}