using UnityEngine;

public class TerrainGen : MonoBehaviour
{
    public float terspeed = 15f;
    
    private bool GameOverBool, GameRestarted;

    public GameObject terrainA, TerrainB;



    public float GetSpeed()
    {
        return terspeed;
    }


    public void SetGameOver(bool gameOver, bool gameRestarted)
    {
        GameOverBool = gameOver;
        GameRestarted = gameRestarted;
        terspeed = 0f;
    }



    public void GameOverCheck(int newlevel)
    {
        if (GameOverBool is false && GameRestarted is true)
        {
            TerrainSpeeder(newlevel);
            GameRestarted = false;
        }
    }



    public void TerrainSpeeder(int level)
    {
        switch (level)
        {
            case 1:
                terspeed = 15f;
                break;

            case 2:
                terspeed = 16f;
                break;

            case 3:
                terspeed = 16.75f;
                break;

            case 4:
                terspeed = 17f;
                break;

            case 5:
                terspeed = 17.5f;
                break;

        }
    }


    private void FixedUpdate()
    {
        terrainA.transform.Translate(0, 0, terspeed * Time.deltaTime);
        TerrainB.transform.Translate(0, 0, terspeed * Time.deltaTime);
    }


}
