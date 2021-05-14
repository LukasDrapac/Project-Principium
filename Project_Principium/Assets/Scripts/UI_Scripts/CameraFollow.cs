using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float Offset;

    GameObject playerObject;
    Vector3 CameraPosition;
    Transform playerPosition;

    void Update()
    {
        SetCameraPosition();
    }

    public void FindPlayerToFollow()
    {
        playerObject = GameObject.Find("Player(Clone)");
        playerPosition = playerObject.transform;
    }

    void SetCameraPosition()
    {
        if (playerObject != null)
        {
            CameraPosition.x = playerPosition.position.x;
            CameraPosition.y = playerPosition.position.y;
            CameraPosition.z = playerPosition.position.z + Offset;

            transform.position = CameraPosition;
        }
    }

}
