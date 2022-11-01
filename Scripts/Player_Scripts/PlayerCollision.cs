using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerController player1;
    WorldController WorldCtrl;

    private void Awake()
    {
        player1 = GameObject.Find("player1").GetComponent<PlayerController>();
        WorldCtrl = GameObject.Find("MainController").GetComponent<WorldController>();
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("Cube1"))
        {
            _ = col.gameObject.name[..7];
            int cubeType = 1;

            col.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

            player1.SetKillKinematic(false, true, cubeType);

            GameObject.Find("Tor_master").GetComponent<Rigidbody>().velocity = new Vector3(0, 0, -10f);

            WorldCtrl.GameOverWorld();
        }
    }
}
