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

    Rigidbody2D rigidBody;
    public Animator animator;

    bool isAbleToJump = true;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
  
    void Update()
    {        
        movementControl();        
        jumpControlFunction();
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "Ground")
        {
            doubleJumpLimit = 0;
            isAbleToJump = true;
        }        
    }

    void jumpControlFunction()
    {
        if (jumpButtonPressed() && isAbleToJump)        // Podmínka stisknu tlačítka a povolení pro skok (zamezení vícenásobnému skoku)
        {
            canPlayerJump();            
        }

        if (rigidBody.velocity.y <= 0)       // Podmínka zajišťující zrychlený pád postavy
        {
            rigidBody.velocity = rigidBody.velocity + Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;       // Kód zajišťující pád postavy ze skoku
        }
    }

    void canPlayerJump()
    {
        if (doubleJumpLimit < 2)
        {
            rigidBody.velocity = Vector2.up * jumpVelocity;     // Zajištění skoku se zvolenou Velocity
            doubleJumpLimit += 1;
        }
        else
        {
            isAbleToJump = false;
        }
    }

    bool jumpButtonPressed()
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

    void movementControl()
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

    void movementAnimationControl()
    {
        animator.SetFloat("Speed", Mathf.Abs(xMovementControl));       
    }
}
