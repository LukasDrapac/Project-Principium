using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float movementSpeed;
    public float distance;
    public bool isMoving;
    public Transform groundDetection;
    public LayerMask groundLayer;
    
    private bool movingRight;
    
    float timeToTurn;
    float timeBeforeTurn;
    
    RaycastHit2D groundInfo;
    RaycastHit2D wallInfo;
    
    void Start()
    {
        timeToTurn = 0;
        isMoving = true;
        timeBeforeTurn = Random.Range(200f, 500f) / 100f;
    }
    void Update()
    {
        if (isMoving == true)
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }

        isGroundInRange();
        isWallInRange();
        isTimeToTurn();
        changeDirection();        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector2 groundDetectionRay = groundDetection.TransformDirection(Vector2.down) * distance;
        Gizmos.DrawRay(groundDetection.position, groundDetectionRay);

        Gizmos.color = Color.red;
        Vector2 wallDetection = groundDetection.TransformDirection(Vector2.left) * distance;
        Gizmos.DrawRay(groundDetection.position, wallDetection);
    }   

    void isWallInRange()
    {
        wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.left, distance, groundLayer);
        if (wallInfo.collider == true)
        {
            movingRight = !movingRight;
            timeToTurn = 0;
        }
    }

    void isGroundInRange()
    {
        groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);

        if (groundInfo.collider == false)
        {
            movingRight = !movingRight;
            timeToTurn = 0;
        }
    }

    void isTimeToTurn()
    {

        if (timeToTurn >= timeBeforeTurn)
        {
            movingRight = !movingRight;
            timeToTurn = 0;
        }
        else if (isMoving == false)
        {

        }
        else
        {
            timeToTurn = timeToTurn + Time.deltaTime;
        }
    }

    void changeDirection()
    {
        if (movingRight == true)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public bool isMovingRight()
    {
        return movingRight;
    }

    public bool isEnemyMoving(bool isEnemyMoving)
    {
        isMoving = isEnemyMoving;
        return isMoving;
    }
}
