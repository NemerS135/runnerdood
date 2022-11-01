using UnityEngine;

public class EndCube : MonoBehaviour
{
    string cubeName;
    private void OnTriggerEnter(Collider cube)
    {
        if (cube.gameObject.name[..3] == "Typ")
        {
            cubeName = cube.gameObject.name;
            GameObject.Find(cubeName).GetComponent<CubeCS>().InitParticles();
            GameObject.Find(cubeName).GetComponent<CubeCS>().KillCube();
        }
    }
}
