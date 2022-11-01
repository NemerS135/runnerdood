using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    private float spinVector = 1;

    private readonly float destoryTime = 1.45f;

    Vector3 popLoc = new(0, -0.5f, 0);

    TextMeshPro scoreText;

    private float scoreMulti;

    public void ScoreMultiSet(float scoreMulti)
    {
        this.scoreMulti = scoreMulti;
    }

    public void SetSpinFunction(float newSpinVector)
    {
        this.spinVector = newSpinVector;
    }

    void Start()
    {
        scoreText = GetComponent<TextMeshPro>();

        scoreText.text = "+"+ scoreMulti;

        Destroy(gameObject, destoryTime);

        transform.localPosition += popLoc;

        transform.localScale = new Vector3(0.28f, 0.28f, 1.0f);

        gameObject.GetComponent<Rigidbody>()
            .AddRelativeTorque(new Vector3(0, 1, 0) * 250.0f, ForceMode.Force);
        gameObject.GetComponent<Rigidbody>()
            .AddForce(new Vector3(0, 1, 0) * 2, ForceMode.Impulse);
    }

}
