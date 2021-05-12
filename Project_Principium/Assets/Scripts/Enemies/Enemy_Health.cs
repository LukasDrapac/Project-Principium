using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public float maxHealth;     // Maximální životy nepřítele
    private float Health;       // Aktuální životy nepřítele

    public GameObject playerObject;
    void Start()
    {
        Health = maxHealth;
    }
    // Funkce volaná při zásahu protivníka útokem
    public void TakeDamage(float damage)
    {
        Health = Health - damage;
        //Debug.Log(Health + "/" + maxHealth);

        if (isEnemyDead(Health))
        {
            //Debug.Log("Enemy Died!");
            dropEssenceOnDeath();
            Destroy(gameObject);
        }
    }

    void dropEssenceOnDeath()
    {
        Debug.Log("Drop");
        playerObject.GetComponent<Player_Item_Drop>().dropEssenceOnDeath();        
    }

    bool isEnemyDead(float Health)
    {
        bool isEnemyDead;
        if(Health <= 0)
        {
            isEnemyDead = true;
        }
        else
        {
            isEnemyDead = false; 
        }
        return isEnemyDead;
    }
}
