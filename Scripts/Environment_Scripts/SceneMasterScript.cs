using UnityEngine;

public class SceneMasterScript : MonoBehaviour
{
    //public GameObject array for planets!
    public GameObject[] planets_Array = new GameObject[4];

    // sound !
    bool soundToggle = false;

    private readonly float Xcord = 430;
    private readonly float Ycord = -840;
    private readonly float Zcord = 1880;

    private readonly float Xrot = 92f;
    private readonly float Y_Z_rot = -1.5f;
    
    void PlanetMaker(float Xcord, float Ycord, float Zcord, GameObject planetPrefab)
    {
        GameObject planet = Instantiate(planetPrefab) as GameObject;
        planet.transform.position = new Vector3(Xcord, Ycord, Zcord); // init postion !
        planet.transform.rotation = Quaternion.Euler(Xrot, Y_Z_rot, Y_Z_rot);  // init rotation !
        planet.transform.localScale  = new Vector3(400f, 400f, 400f); // set planet scale !
        planet.transform.SetParent(this.gameObject.transform);
    }


    public void MusicToggle()
    {
        soundToggle = !soundToggle;
        if (soundToggle)
        {
            this.gameObject.GetComponent<AudioSource>().mute = true;
                   }
        else
        {
            this.gameObject.GetComponent<AudioSource>().mute = false;
                    }
    }

   private void Start()
    {
        int planetPos = Random.Range(0, 4);
        PlanetMaker( Xcord,  Ycord,  Zcord, planets_Array[planetPos]);
        this.gameObject.GetComponent<AudioSource>().Play();
            }

}
