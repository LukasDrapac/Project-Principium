using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevating_Map_Generation : MonoBehaviour
{
    void Start()
    {
        GameObject newElevatingTile = gameObject;
        Transform newMapTilePosition = gameObject.transform;
        newElevatingTile.GetComponentInParent<Map_Generation_Script>().SpawnElevatingTile(newMapTilePosition);
    }
}
