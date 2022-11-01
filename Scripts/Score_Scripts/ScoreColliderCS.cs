using UnityEngine;

public class ScoreColliderCS : MonoBehaviour
{
    public GameObject scorePopup;
    GameObject scorePopupText;

    private float spinVector = 1;

    private readonly float yloc = 2f;
    private readonly float zloc = -4.0f;

    private float scoreMultiplier = 1.0f;

    public void SetSpinVector(float newSpinVector)
         {
        spinVector = newSpinVector;
              }

    

    public void SetScoreMulti(float newScoreMulti)
     {
        scoreMultiplier += newScoreMulti;
            }


    private void OnTriggerEnter(Collider col)
     {
        if (col.gameObject.name != "EndCubeCol")
        {
                // instantiate score popup  !
                scorePopupText = Instantiate(scorePopup, transform.position, Quaternion.identity, transform) as GameObject;
                scorePopupText.transform.localPosition = new Vector3(0, yloc, zloc);

                scorePopupText.GetComponent<FloatingText>().ScoreMultiSet(scoreMultiplier);
                scorePopupText.GetComponent<FloatingText>().SetSpinFunction(spinVector);
            
            // increment score value !
            GameObject.Find("ScoreComponent").GetComponent<ScoreCS>().RaiseScore();
        }
       
    }
}
