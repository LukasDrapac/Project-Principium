using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public float maxHealth;     
    private float Health;       

    GameObject playerObject;

    void Start()
    {
        Health = maxHealth;
        FindPlayerGameObject();
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;


        if (isEnemyDead(Health))
        {
            DropEssenceOnDeath();
            Destroy(gameObject);
        }
    }

    void DropEssenceOnDeath()
    {
        playerObject.GetComponent<Player_Item_Drop>().DropEssenceOnDeath();        
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

    void FindPlayerGameObject()
    {
        playerObject = GameObject.Find("Player(Clone)");

        if(playerObject == null)
        {
            Debug.LogError("GameObject Player(Clone) not found! Enemy_Health.cs");
        }
    }
}
