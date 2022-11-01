using UnityEngine;
using TMPro;

public class LiveCountCS : MonoBehaviour
{
    private TextMeshProUGUI liveCountNum;

    WorldController lvl_manager;


    public void SetLiveCount(int localCount)
    {
        this.liveCountNum.text = "" + localCount;
    }

    private void Awake()
    {
        liveCountNum = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        lvl_manager = GameObject.Find("MainController").GetComponent<WorldController>();

        this.liveCountNum.text = "" + lvl_manager.GetLives();
    }


}
