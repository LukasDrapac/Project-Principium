using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Item_Drop : MonoBehaviour
{
    public float bloodEssenceDropChance;
    public float magicEssenceDropChance;
    public float soulEssenceDropChance;
    public float dropChance;

    public GameObject bloodEssenceUIText;
    public GameObject magicEssenceUIText;
    public GameObject soulEssenceUIText;
    void Awake()
    {
        soulEssenceUIText = GameObject.Find("Soul_Essence_Quantity");
        bloodEssenceUIText = GameObject.Find("Blood_Essence_Quantity");
        magicEssenceUIText = GameObject.Find("Magic_Essence_Quantity");
    }

    public void dropEssenceOnDeath()
    {
        
        int randomNumber;
        randomNumber = Random.Range(0, 100);
        //Debug.Log("Chance was " + randomNumber);

        if (randomNumber < dropChance)
        {
            float blood = Random.Range(0, 100) * bloodEssenceDropChance;
            float magic = Random.Range(0, 100) * magicEssenceDropChance;
            float soul = Random.Range(0, 100) * soulEssenceDropChance;

            if (chanceForDropComputed(blood, magic, soul) == soul)
            {
                //Debug.Log("Soul Essence");               
                soulEssenceUIText.GetComponent<Soul_Essence_Quantity_Script>().changeQuantity(1);
            }
            else if (chanceForDropComputed(blood, magic, soul) == blood)
            {
                //Debug.Log("Blood Essence");
                bloodEssenceUIText.GetComponent<Blood_Essence_Quantity_Script>().changeQuantity(1);
            }
            else if (chanceForDropComputed(blood, magic, soul) == magic)
            {
                //Debug.Log("Magic Essence");               
                magicEssenceUIText.GetComponent<Magic_Essence_Quantity_Script>().changeQuantity(1);
            }
        }
    }

    float chanceForDropComputed(float blood, float magic, float soul)
    {
        return Mathf.Max(blood, magic, soul);
    }
    

}



