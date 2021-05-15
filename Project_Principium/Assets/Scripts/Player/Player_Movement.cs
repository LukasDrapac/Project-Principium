using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float playerMoveSpeed;             
    public float jumpVelocity;          
    public float fallMultiplier;        
    private int doubleJumpLimit;             
    private float xMovementControl;          
    public float jumpHeightLimit;
    public float airFriction;
    Rigidbody2D rigidBody;
    public Animator animator;

    bool isAbleToJump = true;


    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.drag = airFriction;
    }
  
    void Update()
    {        
        MovementControl();        
        JumpControlFunction();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "Ground")
        {
            rigidBody.drag = airFriction;
            doubleJumpLimit = 0;
            isAbleToJump = true;
        }        
    }

    void JumpControlFunction()
    {
        if (JumpButtonPressed() && isAbleToJump)        
        {
            rigidBody.drag = airFriction;
            CanPlayerJump();            
        }

        if (rigidBody.velocity.y <= 0)       
        {
            rigidBody.drag = 0;
            rigidBody.velocity = rigidBody.velocity + Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;       
        }
    }

    void CanPlayerJump()
    {
        if (doubleJumpLimit < 2)
        {
            rigidBody.velocity = Vector2.up * jumpVelocity;     
            doubleJumpLimit += 1;
        }
        else
        {
            isAbleToJump = false;
        }
    }

    bool JumpButtonPressed()
    {
        
        if(Input.GetButtonDown("Jump") && Input.GetKey(KeyCode.S)){
            return false;
        }
        else if (Input.GetButtonDown("Jump"))
        {
            return true;
        }
        else { return false; }
    }

    void MovementControl()
    {
        xMovementControl = Input.GetAxis("Horizontal");
        if(xMovementControl > 0)
        {
            Vector2 position = transform.position;
            position.x = position.x + playerMoveSpeed * xMovementControl * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position = position;
        }
        else if(xMovementControl < 0)
        {
            Vector2 position = transform.position;
            position.x = position.x + playerMoveSpeed * xMovementControl * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, -180, 0);
            transform.position = position;            ;
        }
        
       
    }

    void MovementAnimationControl()
    {
        animator.SetFloat("Speed", Mathf.Abs(xMovementControl));       
    }
}
