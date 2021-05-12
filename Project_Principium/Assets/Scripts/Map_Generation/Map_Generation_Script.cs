using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Generation_Script : MonoBehaviour
{
    public GameObject[] leftMapTiles;
    public GameObject[] rightMapTiles;
    public GameObject[] bottomMapTiles;
    public GameObject[] upMapTiles;
    public GameObject[] elevatingMapTiles;
    public GameObject[] descendMapTiles;

    public int maxMapLength;
    public int elevationTilesDistance;

    private int[] branches;
    private int currentMapLength;
    private int nextElevatingTile;

    private void Awake()
    {
        currentMapLength = 0;
        nextElevatingTile = 0;
    }

    public void spawnLeftMapTile(Transform newMapTilePosition)
    {
        if(currentMapLength <= maxMapLength)
        {
            
            if (nextElevatingTile >= elevationTilesDistance)
            { 
                if (Random.Range(0, 100) >= 50)
                {                    
                    currentMapLengthIncrement();
                    instantiateLeftMapTile(newMapTilePosition);
                }
                else{
                    currentMapLengthIncrement();
                    nextElevatingTile = 0;
                    instantiateUpMapTile(newMapTilePosition);
                }                
            }
            else
            {
                currentMapLengthIncrement();
                nextUpTileIncrement();
                instantiateLeftMapTile(newMapTilePosition);
            }           
        }
        else
        {
            Debug.Log("Map Complete");
        }
        
    }

    void currentMapLengthIncrement()
    {
        currentMapLength += 1;
    }
    void nextUpTileIncrement()
    {
        nextElevatingTile += 1;
    }

    int getRandomTile(GameObject[] tileArray)
    {
        return Random.Range(0, tileArray.Length);
    }

    void instantiateLeftMapTile(Transform newMapTilePosition)
    {
        GameObject newMapTile = Instantiate(leftMapTiles[getRandomTile(leftMapTiles)], newMapTilePosition);
    }

    void instantiateUpMapTile(Transform newMapTilePosition)
    {
        GameObject newMapTile = Instantiate(upMapTiles[getRandomTile(upMapTiles)], newMapTilePosition);
    }

    public void spawnElevatingTile(Transform newMapTilePosition)
    {
        GameObject newElevatingTile = Instantiate(elevatingMapTiles[0], newMapTilePosition);
    }
}
