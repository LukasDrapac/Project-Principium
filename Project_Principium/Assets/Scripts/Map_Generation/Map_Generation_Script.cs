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
    public bool mapGenerationDisabled;
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
        if(currentMapLength <= maxMapLength && !mapGenerationDisabled)
        {
            
            if (nextElevatingTile >= elevationTilesDistance)
            { 
                if (Random.Range(0, 100) >= 50)
                {                    
                    CurrentMapLengthIncrement();
                    InstantiateLeftMapTile(newMapTilePosition);
                }
                else{
                    CurrentMapLengthIncrement();
                    nextElevatingTile = 0;
                    InstantiateUpMapTile(newMapTilePosition);
                }                
            }
            else
            {
                CurrentMapLengthIncrement();
                NextUpTileIncrement();
                InstantiateLeftMapTile(newMapTilePosition);
            }           
        }
        else
        {
            //Debug.Log("Map Complete");
        }
        
    }

    void CurrentMapLengthIncrement()
    {
        currentMapLength += 1;
    }
    void NextUpTileIncrement()
    {
        nextElevatingTile += 1;
    }

    int GetRandomTile(GameObject[] tileArray)
    {
        return Random.Range(0, tileArray.Length);
    }

    void InstantiateLeftMapTile(Transform newMapTilePosition)
    {
        GameObject newMapTile = Instantiate(leftMapTiles[GetRandomTile(leftMapTiles)], newMapTilePosition);
    }

    void InstantiateUpMapTile(Transform newMapTilePosition)
    {
        GameObject newMapTile = Instantiate(upMapTiles[GetRandomTile(upMapTiles)], newMapTilePosition);
    }

    public void SpawnElevatingTile(Transform newMapTilePosition)
    {
        GameObject newElevatingTile = Instantiate(elevatingMapTiles[GetRandomTile(elevatingMapTiles)], newMapTilePosition);
    }
}
