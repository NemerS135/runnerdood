using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Animator anim;

    private GameObject player;
    
    private Rigidbody rg;

    private AudioSource hitSound;

    private Vector2 fingerDownPos;
    private Vector2 fingerUpPos;
    readonly float SWIPE_THRESHOLD = 20f;

    private IEnumerator WaitForDead()
    {
        yield return new WaitForSeconds(1.0f);
            player.SetActive(false);
       }



    public void RespawnPlayer(int level)
    {
        player.transform.localPosition = new Vector3(5.5f, 0, 147.0f);
        player.transform.localRotation = Quaternion.Euler(0, 170, 0);

        SetStartKinematic(true, false);

        // resume animation speed to sync with level
        AnimSpeed(level);

    }



    private Vector3 VectorDir()
        { // X : Fw/Bk    Y: Up/Dw    Z: R/L
        return new Vector3(1, 1, 0) * 1; // GreenCube
            }

    public void SetKillKinematic(bool Kibool, bool Gravbool, int cubeType)
         {
                 // run Hit-sound !
                 hitSound.Play(0);
        
                 //Get an array of components that are of type Rigidbody
                 Component[] components = GetComponentsInChildren<Rigidbody>();

                //For each component as a rigibody from childern !
                 for (int i = 0; i < components.Length; i++)
                 {
                    (components[i] as Rigidbody).isKinematic = Kibool;

                    (components[i] as Rigidbody).useGravity = Gravbool;

                    (components[i] as Rigidbody).AddForce(VectorDir(), ForceMode.Impulse);

                    }
                
                // Disable animator > enforce physics !
                anim.enabled = false;
        
                // end kill player
               StartCoroutine(WaitForDead());
            }

    void SetStartKinematic(bool Kibool, bool Gravbool)
      {

                //Get an array of components that are of type Rigidbody
                Component[] components = GetComponentsInChildren<Rigidbody>();

                //For each component as a rigibody from childern !
                for (int i = 0; i < components.Length; i++)
                {
                    (components[i] as Rigidbody).isKinematic = Kibool;

                    (components[i] as Rigidbody).useGravity = Gravbool;

                }
                // enable the animator !
                anim.enabled = true;
            }




    private void Awake()
     {
        anim = GetComponent<Animator>();
        player = this.gameObject;
        SetStartKinematic(true, false);
        rg = player.GetComponent<Rigidbody>();
        hitSound = player.GetComponent<AudioSource>();

            }

    public void AnimSpeed(int level)
    {
        switch(level)
        {
            case 1:
                {
                    anim.speed = 1f;
                }
                break;
            case 2:
                {
                    anim.speed = 1.1f;
                }
                break;
            case 3:
                {
                    anim.speed = 1.2f;
                }
                break;
            case 4:
                {
                    anim.speed = 1.3f;
                }
                break;
            case 5:
                {
                    anim.speed = 1.35f;
                }
                break;
        }
        
    }


    float VerticalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.y - fingerUpPos.y);
    }

    float HorizontalMoveValue()
    {
        return Mathf.Abs(fingerDownPos.x - fingerUpPos.x);
    }

    void OnSwipeUp()
    {
        anim.SetTrigger("Flip");
    }

    void OnSwipeDown()
    {
        anim.SetTrigger("Slide");
    }

    void OnSwipeLeft()
    {
        anim.SetTrigger("Jump");
    }

    void OnSwipeRight()
    {
        anim.SetTrigger("Roll");
    }

    void OnTapTouch()
    {
        anim.SetTrigger("Jump");
    }

    void DetectSwipe()
    {

        if (VerticalMoveValue() > SWIPE_THRESHOLD && VerticalMoveValue() > HorizontalMoveValue())
        {
            if (fingerDownPos.y - fingerUpPos.y > 0)
            {
                OnSwipeUp();
            }
            else if (fingerDownPos.y - fingerUpPos.y < 0)
            {
                OnSwipeDown();
            }
            fingerUpPos = fingerDownPos;

        }
        else if (HorizontalMoveValue() > SWIPE_THRESHOLD && HorizontalMoveValue() > VerticalMoveValue())
        {
            if (fingerDownPos.x - fingerUpPos.x > 0)
            {
                OnSwipeRight();
            }
            else if (fingerDownPos.x - fingerUpPos.x < 0)
            {
                OnSwipeLeft();
            }
            fingerUpPos = fingerDownPos;

        }
        else if ((HorizontalMoveValue() < SWIPE_THRESHOLD) && (HorizontalMoveValue() < SWIPE_THRESHOLD))
        {
            OnTapTouch();
        }
    }

   
    
    
    
    private void Update()
    {

        foreach (Touch touch in Input.touches)
        {
            if (!(EventSystem.current.IsPointerOverGameObject() || EventSystem.current.currentSelectedGameObject != null))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    fingerUpPos = touch.position;
                    fingerDownPos = touch.position;
                }

                //Detects swipe after finger is released from screen
                if (touch.phase == TouchPhase.Ended)
                {
                    fingerDownPos = touch.position;
                    DetectSwipe();
                }
            }
        }
    }
}

