using UnityEngine;

public class TerrainColliderCS : MonoBehaviour
{
    string cubeName;

    private void OnTriggerEnter(Collider cube)
    {
            cubeName = cube.gameObject.name;
            GameObject.Find(cubeName).GetComponent<TerrainRePos>().ResetPos();
    }
}
