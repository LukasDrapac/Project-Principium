using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    public float Damage;                // Útočné číslo nepřítelova útoku
    public float AttackRange;           // Range neřpítelova útoku
    public float DetectionRange;        // Range, ve kterém nepřítel detekuje hráče
    public float attackChargeTime;      // Prodleva meze jednotlivými útoky

    public LayerMask playerLayer;       // Vrstva, ve které je detekován hráč

    public Transform attackPosition;    // Souřadnice Gizma

    public Animator animator;
    private float attackTime;           // Pomocná proměnná - uchovává čas do udělení poškození v místě útoku
    private bool isAttacking;           // Pomocná proměnná - uchovává informaci o tom, jestli nepřítel chystá útok/útočí
    public bool attackWasTriggered;

    RaycastHit2D damageToPlayer;
    RaycastHit2D playerDetected;
    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
        attackTime = attackChargeTime;
        attackWasTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNPCMovingRight())
        {
            playerDetectionRight();
        }
        else
        {
            playeDetectionLeft();
        }

        if (playerDetected)     // Podmínka hlídá, jestli byl detekován hráč funkcí RayCast
        {
            isAttacking = true;
            animator.SetBool("Attack", true);


            if (!attackWasTriggered)
            {
                animator.SetTrigger("Attack_Prepare");
                attackWasTriggered = true;
                gameObject.GetComponent<Enemy_Movement>().isEnemyMoving(false);
            }

        }


        if (isAttacking)         
        {
            if (attackTime <= 0)       
            {
                isAttacking = false;
                attackTime = attackChargeTime;

                if (isNPCMovingRight())
                {
                    dealDMGRight();
                }
                else
                {
                    dealDMGLeft();
                }

                if (damageToPlayer)
                {
                    Collider2D playerToTakeDamage = damageToPlayer.collider;
                    playerToTakeDamage.GetComponent<Player_Health>().TakeDamage(Damage);                           
                }

                if (!playerDetected)
                {
                    animator.SetBool("Attack", false);
                    attackWasTriggered = false;
                    gameObject.GetComponent<Enemy_Movement>().isEnemyMoving(true);
                }
                
            }
            else
            {
                attackTime -= Time.deltaTime;
            }
        }
  
        


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 AttackDirection = attackPosition.TransformDirection(Vector2.left) * AttackRange;
        Gizmos.DrawRay(attackPosition.position, AttackDirection);

        Gizmos.color = Color.blue;
        Vector2 PlayerDetectionRange = attackPosition.TransformDirection(Vector2.left) * DetectionRange;
        Gizmos.DrawRay(attackPosition.position, PlayerDetectionRange);
    }

    bool isNPCMovingRight()
    {
        return gameObject.GetComponent<Enemy_Movement>().isMovingRight();
    }

    void playeDetectionLeft()
    {
        playerDetected = Physics2D.Raycast(attackPosition.position, Vector2.left, DetectionRange, playerLayer);  
       
    }

    void playerDetectionRight()
    {
        playerDetected = Physics2D.Raycast(attackPosition.position, Vector2.right, DetectionRange, playerLayer);  
    }

    void dealDMGLeft()
    {
        damageToPlayer = Physics2D.Raycast(attackPosition.position, Vector2.left, AttackRange, playerLayer);
    }

    void dealDMGRight()
    {
        damageToPlayer = Physics2D.Raycast(attackPosition.position, Vector2.right, AttackRange, playerLayer);
    }
}
