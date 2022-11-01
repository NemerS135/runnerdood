using UnityEngine;

public class WorldSelector : MonoBehaviour
{
    // world selected : default 1 : desert
     int worldSelect = 1;

    readonly string worldSelected = "WorldSelected";


    // chang scene load !
    public void WorldSelectSet(string worldName)
    {
        if(worldName == "Desert_World")
        {
            this.worldSelect = 1;
            PlayerPrefs.SetInt(worldSelected, 1);
        }
        else if (worldName == "Snow_World")
        {
            this.worldSelect = 2;
            PlayerPrefs.SetInt(worldSelected, 2);
        }
    }

    // get scene load !
    public int WorldSelectGet()
    {
        return this.worldSelect;
    }



}
