using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Player : MonoBehaviour
{
    public float xPosition;
    public float yPosition;

    public GameObject playerToSpawn;
    public Transform spawnPosition;

    Object player;

    void Awake()
    {
        spawnPlayer();
        setCameraPositionToPlayer();
    }

    
    void spawnPlayer()
    {
        spawnPosition.position = new Vector3(spawnPosition.position.x + xPosition, spawnPosition.position.y + yPosition, 0);
        player = Instantiate(playerToSpawn, spawnPosition) as GameObject;
    }

    void setCameraPositionToPlayer()
    {
        GameObject camera = GameObject.Find("Main Camera");
        camera.GetComponent<CameraFollow>().FindPlayerToFollow();       
    }
}
