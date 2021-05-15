using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Upstairs_Generation : MonoBehaviour
{
    void Start()
    {
        GameObject newTile = gameObject;
        newTile.GetComponentInParent<Floor_Generation_Management>().SpawnLeftMapTile(transform);
    }
}
