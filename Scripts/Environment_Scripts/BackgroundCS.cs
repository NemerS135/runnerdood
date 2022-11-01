using UnityEngine;

public class BackgroundCS : MonoBehaviour
{
    private float speed;
    Renderer bgRenderer;
    Vector2 offsetRend;
    
    public void SetSpeed(int level)
    {
        switch(level)
        {
            case 0:
                {
                    this.speed = 0;
                }
                break;
            case 1:
                {
                    this.speed += 0.035f;
                    //Debug.Log("level at (1) > current background speed : " + this.speed);
                }
                break;
            case 2:
                {
                    // is now > 0.05
                    this.speed += 0.015f;
                    //Debug.Log("level at (2) > current background speed : " + this.speed);
                }
                break;
            case 3:
                {
                    // is now 0.065
                    this.speed += 0.015f;
                    //Debug.Log("level at (3) > current background speed : " + this.speed);
                }
                break;
            case 4:
                {
                    // is now 0.080
                    this.speed += 0.015f;
                    //Debug.Log("level at (4) > current background speed : " + this.speed);
                }
                break;
            case 5:
                {
                    // is now 0.09
                    this.speed += 0.015f;
                    //Debug.Log("level at (5) > current background speed : " + this.speed);
                }
                break;
            case 6:
                {
                    this.speed = 0.115f;
                    //Debug.Log("last level at (6) > current background speed : " + this.speed);
                }
                break;
        }
        
    }

    float GetSpeed()
    {
        return this.speed;
    }

    void Start()
    {
        this.speed = 0.035f;
        bgRenderer = GetComponent<Renderer>();
    }


    void LateUpdate()
    {
        offsetRend.x += Time.deltaTime * GetSpeed();
        bgRenderer.material.mainTextureOffset = offsetRend;
    }
}
