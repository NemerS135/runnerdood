using UnityEngine;

public class TutorialCube : MonoBehaviour
{
    RectTransform m_RectTransform;

    public void KillCube()
    {
        Destroy(gameObject);
    }


    void Start()
    {
        m_RectTransform = gameObject.GetComponent<RectTransform>();
        Invoke("KillCube",7.0f); // 

    }

    private void FixedUpdate()
    {
        m_RectTransform.transform.Translate(-7.0f * Time.deltaTime, 0, 0);
    }
}
