using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Map_Generation : MonoBehaviour
{

    void Awake()
    {
        GameObject newLeftTile = gameObject;
        Transform newLeftTilePosition = gameObject.transform;

        newLeftTile.GetComponentInParent<Map_Generation_Script>().spawnLeftMapTile(newLeftTilePosition);
    }

 
}
