using UnityEngine;

public class MusicCS : MonoBehaviour
{
    // sound !
    bool soundToggle = false;

    public void MusicToggle()
    {
        soundToggle = !soundToggle;
        if (soundToggle)
        {
            gameObject.GetComponent<AudioSource>().mute = true;
                    }
        else
        {
            gameObject.GetComponent<AudioSource>().mute = false;
                  }
    }

    void Start()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
}
