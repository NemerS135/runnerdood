using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    private readonly float torque_var = -500;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddTorque(new Vector3(0, 1, 0) * torque_var, ForceMode.Force);
    }
}
