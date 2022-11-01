using UnityEngine;

public class MainCubeCS : MonoBehaviour
{

    private int masterLevel = 1;


    // gameover boolean !
    private bool GameOver = false;

    //speed !!
    private float speed = 7.0f;

    // freq  var !
    private float spawnFreq = 4.0f;

    // make this bigger !
    public GameObject[,] masterArray = new GameObject[4, 3];

    public GameObject[,] tutorialCubesArray = new GameObject[1, 4];

    public GameObject tutorial1, tutorial2, tutorial3, tutorial4;


    // here we should make a loop mod to auto take-in all typ-cube objects
    void SetupCubeArrays()
    {
        this.masterArray[0, 0] = Resources.Load("lo_cube/Typ-Low0") as GameObject;
        this.masterArray[1, 0] = Resources.Load("mid_cube/Typ-Mid0") as GameObject;
        this.masterArray[2, 0] = Resources.Load("hi_cube/Typ-Hig0") as GameObject;
        this.masterArray[3, 0] = Resources.Load("hi_plus_cube/Typ-Hpc0") as GameObject;

        this.masterArray[0, 1] = Resources.Load("lo_cube/Typ-Low1") as GameObject;
        this.masterArray[1, 1] = Resources.Load("mid_cube/Typ-Mid1") as GameObject;
        this.masterArray[2, 1] = Resources.Load("hi_cube/Typ-Hig1") as GameObject;
        this.masterArray[3, 1] = Resources.Load("hi_plus_cube/Typ-Hpc1") as GameObject;

        this.masterArray[0, 2] = Resources.Load("lo_cube/Typ-Low2") as GameObject;
        this.masterArray[1, 2] = Resources.Load("mid_cube/Typ-Mid2") as GameObject;
        this.masterArray[2, 2] = Resources.Load("hi_cube/Typ-Hig2") as GameObject;
        this.masterArray[3, 2] = Resources.Load("hi_plus_cube/Typ-Hpc2") as GameObject;
    }

    GameObject GitCube(int cubeTypeIndex, int cubeIndex)
    {
        return masterArray[cubeTypeIndex, cubeIndex];
    }


    // cube position int for Random !
    private int cubePos;
    private int cubePos_flag = 1;


    // General accessors for spawn frequency & speed !
    float GetSpawnFreq_Float()
    {
        return this.spawnFreq;
    }

    void SetSpawnFreq_Float(float newfreq)
    {
        this.spawnFreq = newfreq;
    }

    float GetSpeed()
    {
        return this.speed;
    }

    void SetSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }

    int GetMasterLevel()
    {
        return this.masterLevel;
    }

    void SetMasterLevel(int newLevel)
    {
        this.masterLevel = newLevel;
    }



    public void SetSpawnFreq(int level)
    {

        switch (level)
        {
            case 1:
                {
                    CancelInvoke(nameof(SpawnCube));
                    SetMasterLevel(level);
                    SetSpawnFreq_Float(4.0f);
                    SetSpeed(7.0f);
                    InvokeRepeating(nameof(SpawnCube), 3.0f, GetSpawnFreq_Float());
                }
                break;
            case 2:
                {
                    CancelInvoke(nameof(SpawnCube));
                    SetMasterLevel(level);
                    SetSpawnFreq_Float(3.75f);
                    SetSpeed(8.0f);
                    InvokeRepeating(nameof(SpawnCube), 3.90f, GetSpawnFreq_Float());
                }
                break;
            case 3:
                {
                    CancelInvoke(nameof(SpawnCube));
                    SetMasterLevel(level);
                    SetSpawnFreq_Float(3.5f);
                    SetSpeed(8.75f);
                    InvokeRepeating(nameof(SpawnCube), 2.75f, GetSpawnFreq_Float());
                }
                break;
            case 4:
                {
                    CancelInvoke(nameof(SpawnCube));
                    SetMasterLevel(level);
                    SetSpawnFreq_Float(3.25f);
                    SetSpeed(9.5f);
                    InvokeRepeating(nameof(SpawnCube), 2.70f, GetSpawnFreq_Float());
                }
                break;
            case 5:
                {
                    CancelInvoke(nameof(SpawnCube));
                    SetMasterLevel(level);
                    SetSpawnFreq_Float(3.0f);
                    SetSpeed(10.25f);
                    InvokeRepeating(nameof(SpawnCube), 2.65f, GetSpawnFreq_Float());
                }
                break;
            case 6:
                {
                    CancelInvoke(nameof(SpawnCube));
                    SetMasterLevel(level);
                    SetSpawnFreq_Float(2.75f);
                    SetSpeed(11.0f);
                    InvokeRepeating(nameof(SpawnCube), 2.60f, GetSpawnFreq_Float());
                }
                break;
        }

    }




    void CubeMaker(GameObject cubePrefab)
    {
        // intialize & give tag + name !
        GameObject cube = Instantiate(cubePrefab) as GameObject;
        cube.tag = "Cube1";
        cube.name = cubePrefab.name + " > ID :  " + Random.Range(99, 999);

        // start moving the cube !
        cube.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, +speed);
        
    }



    void TutorialCube(GameObject tutorialPrefab)
    {
         GameObject tutorial_cube = Instantiate(tutorialPrefab) as GameObject;
         tutorial_cube.name = tutorialPrefab.name + " > ID :  " + Random.Range(99, 999);
    }


    void SpawnCube()
    {
        int level = GetMasterLevel();
       
        // Main switch : spawn based on level !
        switch (level)
        {
            case int when level is < 3 and > 0:

                {
                    //Debug.Log("Spawn at switch level 1 to 2");
                    cubePos = CubetoRandom(0, 4); 

         switch (cubePos)
            {
                case 0: // low : 
                    {
                                CubeMaker(GitCube(0, Random.Range(0, 3))); // low cube
                                TutorialCube(tutorial1);
                    }
                    break;
                case 1: // mid : 
                    {
                                CubeMaker(GitCube(0, Random.Range(0, 3))); // low cube
                                CubeMaker(GitCube(2, Random.Range(0, 3))); // hig cube
                                TutorialCube(tutorial2);
                            }
                    break;
                case 2: // high : 
                    {
                                CubeMaker(GitCube(1, Random.Range(0, 3))); // mid cube
                                CubeMaker(GitCube(2, Random.Range(0, 3))); // hig cube
                                TutorialCube(tutorial4);
                            }
                    break;
                 case 3: // high : 
                      {
                                CubeMaker(GitCube(0, Random.Range(0, 3))); // low cube
                                CubeMaker(GitCube(1, Random.Range(0, 3))); // mid cube
                                TutorialCube(tutorial3);
                            }
                            break;


                    }
        }
        break;

            case int when level is < 5 and > 2:

                {
                    cubePos =  CubetoRandom(0, 4);

                    switch (cubePos)
            {
                case 0:
                    {
                        // << simple jump >>
                         CubeMaker(GitCube(0, Random.Range(0, 3)));
                          CubeMaker(GitCube(3, Random.Range(0, 3)));
                            }
                    break;
                case 1: 
                    {
                                // slide or backflip
                          CubeMaker(GitCube(1, Random.Range(0, 3)));
                           CubeMaker(GitCube(2, Random.Range(0, 3)));
                            }
                    break;
                case 2:  
                    {
                            // vault only
                           CubeMaker(GitCube(0, Random.Range(0, 3)));
                            CubeMaker(GitCube(2, Random.Range(0, 3)));
                             CubeMaker(GitCube(3, Random.Range(0, 3)));
                            }
                    break;
                 case 3: 
                      {
                                // backflip only
                             CubeMaker(GitCube(0, Random.Range(0, 3)));
                              CubeMaker(GitCube(1, Random.Range(0, 3)));
                               CubeMaker(GitCube(3, Random.Range(0, 3)));
                            }
                            break;

                    }
        }
                 break;

            case int when level is < 6 and > 4:

                {
                    cubePos = CubetoRandom(0, 4);

                    switch (cubePos) //
                    {
                case 0:
                    {
                        // backflip only
                         CubeMaker(GitCube(0, Random.Range(0, 3)));
                          CubeMaker(GitCube(1, Random.Range(0, 3)));
                           CubeMaker(GitCube(2, Random.Range(0, 3)));
                            }
                    break;
                case 1:
                    {
                        // slide only
                         CubeMaker(GitCube(1, Random.Range(0, 3)));
                          CubeMaker(GitCube(2, Random.Range(0, 3)));
                           CubeMaker(GitCube(3, Random.Range(0, 3)));
                            }
                    break; 
                case 2:
                    {
                       // vault only
                         CubeMaker(GitCube(0, Random.Range(0, 3)));
                          CubeMaker(GitCube(2, Random.Range(0, 3)));
                           CubeMaker(GitCube(3, Random.Range(0, 3)));
                            }
                    break;
                case 3:
                    {
                     // jump only    
                       CubeMaker(GitCube(0, Random.Range(0, 3)));
                        CubeMaker(GitCube(3, Random.Range(0, 3)));
                    }
                    break;

            }
        }
        break;

            case int when level > 5:

                {
                    cubePos = CubetoRandom(0, 4);

                    switch (cubePos) //
                    {
                        case 0: 
                            {
                                // jump only
                                CubeMaker(GitCube(0, Random.Range(0, 3)));
                                CubeMaker(GitCube(3, Random.Range(0, 3)));
                            }
                            break;
                        case 1: 
                            {
                                // slide only
                                CubeMaker(GitCube(1, Random.Range(0, 3)));
                                CubeMaker(GitCube(2, Random.Range(0, 3)));
                                CubeMaker(GitCube(3, Random.Range(0, 3)));
                            }
                            break;
                        case 2: 
                            {
                                // vault only
                                CubeMaker(GitCube(0, Random.Range(0, 3)));
                                CubeMaker(GitCube(2, Random.Range(0, 3)));
                                CubeMaker(GitCube(3, Random.Range(0, 3)));
                            }
                            break;
                         case 3:
                             {
                                // backflip only
                        CubeMaker(GitCube(0, Random.Range(0, 3)));
                        CubeMaker(GitCube(1, Random.Range(0, 3)));
                        CubeMaker(GitCube(2, Random.Range(0, 3)));
                                 }
                            break;
                        }
                }
                break;
        }
  }



public void FreezeCubes()
    {
        CancelInvoke(nameof(SpawnCube));
        GameOver = true;

        GameObject[] cubeArray = GameObject.FindGameObjectsWithTag("Cube1");

        for (int i = 0; i < cubeArray.Length; i++)
        {
            cubeArray[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }

    }


    public void RestartCubes(int level)
    {
        if (GameOver)
        {
            GameObject[] cubeArray = GameObject.FindGameObjectsWithTag("Cube1");

            for (int i = 0; i < cubeArray.Length; i++)
            { Destroy(cubeArray[i]); }

            SetSpawnFreq(level);
        }
        // reset gameOver vars !
        GameOver = false;
    }




    int CubetoRandom(int minIncluded, int maxExcluded)
    {
        int newrandom = Random.Range(minIncluded, maxExcluded);
        if(newrandom == this.cubePos_flag)
        {
            newrandom = Random.Range(minIncluded, maxExcluded);
            this.cubePos_flag = newrandom;
            return newrandom;
        }
        else
        {
            this.cubePos_flag = newrandom;
            return newrandom;
        }
    }



    private void Start()
    {
        SetupCubeArrays();
        InvokeRepeating(nameof(SpawnCube), 3.0f, GetSpawnFreq_Float());
    }


}
