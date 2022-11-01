using UnityEngine;

public class CubeCS : MonoBehaviour
{
    private float spinVector = 1;

    public GameObject cubeShreds;


    // we use "SerializeField" to set the rotation type/direction from prefab !

    [SerializeField] private float x_Rot_var;
    [SerializeField] private float y_Rot_var;
    [SerializeField] private float z_Rot_var;
   
    GameObject ParticleGraphics;

    Material parentMatreial;

    public void InitParticles()
    {
        parentMatreial = this.gameObject.GetComponent<Renderer>().material as Material;
        cubeShreds.GetComponent<Renderer>().material = parentMatreial;


        ParticleGraphics = Instantiate(cubeShreds, transform.position, Quaternion.Euler(270f,0,0)) as GameObject;
    }

    public void KillCube()
      {
        Destroy(this.gameObject);
         }

    private void Start()
    {
        this.spinVector =  GameObject.Find("MainController").gameObject.GetComponent<WorldController>().GetLevel() * 20;
        this.gameObject.GetComponent<Rigidbody>()

             .AddRelativeTorque(new Vector3(this.x_Rot_var, this.y_Rot_var, this.z_Rot_var)
                 * spinVector, ForceMode.Force); 
  
    }

}
