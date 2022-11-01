using UnityEngine;

public class TerrainRePos : MonoBehaviour
{

    public void ResetPos()
    {
        _ = gameObject.transform.position.z;
        gameObject.transform.position = new Vector3(0, 0, -210);
    }


}
