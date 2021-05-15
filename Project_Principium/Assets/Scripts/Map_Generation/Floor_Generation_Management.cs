using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Generation_Management : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxLeftLength;
    public int maxRightLength;

    private int currentRightLength;
    private int currentLeftLength;

    public GameObject[] leftMapTiles;
    public GameObject[] rightMapTiles;
    public GameObject[] endMapTiles;

    private void Start()
    {
        currentLeftLength = 0;
        currentRightLength = 0;
    }

    public void SpawnRightMapTile(Transform newTilePosition)
    {        
        IncrementRightLength();
        if (currentRightLength < maxRightLength)
        {
            GameObject newTile = Instantiate(rightMapTiles[Random.Range(0, rightMapTiles.Length)], newTilePosition);
        }
        else
        {
            GameObject newTile = Instantiate(endMapTiles[Random.Range(0, endMapTiles.Length)], newTilePosition);
        }
        
    }

    public void SpawnLeftMapTile(Transform newTilePosition)
    {        
        IncrementLeftLength();
        if (currentLeftLength < maxLeftLength)
        {
            GameObject newTile = Instantiate(leftMapTiles[Random.Range(0, leftMapTiles.Length)], newTilePosition);
        }
        else
        {
            GameObject newTile = Instantiate(endMapTiles[Random.Range(0, endMapTiles.Length)], newTilePosition);
        }
        
    }

    void IncrementRightLength()
    {
        currentRightLength += 1;
    }

    void IncrementLeftLength()
    {
        currentLeftLength += 1;
    }
}
