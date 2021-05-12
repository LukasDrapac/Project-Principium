using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    private float timeBtwAttacks;        // Proměnná pro ukládání času, do nejbližšího útoku
    public float startTimeBtwAttack;    // Čas mezi jednotlivými útoky
    public float attackRange;           // Poloměr kruhu útoku
    public float shortSwordDamage;                // Základní poškození udělené nepříteli

    public LayerMask enemyLayer;       // Vrstva (Layer), ve které se budou hledat nepřátelé
    public Transform attackPosition;    // Střed kruhu pro udělení poškození
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        /*************************** Základní útok hráče ************************************/
        if(timeBtwAttacks <= 0)      
        {            
            if (attackButtonPressed())
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, enemyLayer);       // Zjištění, kolik nepřítel je v prostoru útoku hráče
                for(int i = 0; i < enemiesToDamage.Length; i++)     // Cyklus, ve kterém je každému nepříteli uděleno poškození
                {
                    damageEnemy(enemiesToDamage[i]);      
                }
                timeBtwAttacks = startTimeBtwAttack;
                playerAttackAnimationControl();
            }            
        }
        else
        {
            timeBtwAttacks -= Time.deltaTime;
        }
        
    }

    private void OnDrawGizmosSelected()     // Vykreslení range útoku
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange); 
    }

    void playerAttackAnimationControl()
    {
        animator.SetTrigger("Attack");
    }

    void damageEnemy(Collider2D enemyToDamage)
    {
        enemyToDamage.GetComponent<Enemy_Health>().TakeDamage(shortSwordDamage);
    }

    bool attackButtonPressed()
    {
        return Input.GetKeyDown(KeyCode.E);
    }
}
