using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Item_Drop : MonoBehaviour
{
    public float bloodEssenceDropChanceModifier;
    public float magicEssenceDropChanceModifier;
    public float soulEssenceDropChanceModifier;
    public float dropChance;

    GameObject bloodEssenceUIText;
    GameObject magicEssenceUIText;
    GameObject soulEssenceUIText;

    void Awake()
    {
        bloodEssenceUIText = GameObject.Find("Blood_Essence_Quantity");
        magicEssenceUIText = GameObject.Find("Magic_Essence_Quantity");
        soulEssenceUIText = GameObject.Find("Soul_Essence_Quantity");
    }

    public void DropEssenceOnDeath()
    {
        Debug.Log(bloodEssenceUIText);
        int randomNumber;
        randomNumber = Random.Range(0, 100);

        if (randomNumber < dropChance)
        {
            float blood = Random.Range(0, 100) * bloodEssenceDropChanceModifier;
            float magic = Random.Range(0, 100) * magicEssenceDropChanceModifier;
            float soul = Random.Range(0, 100) * soulEssenceDropChanceModifier;

            if (ChanceForDropComputed(blood, magic, soul) == soul)
            {           
                soulEssenceUIText.GetComponent<Soul_Essence_Quantity_Script>().changeQuantity(1);
            }
            else if (ChanceForDropComputed(blood, magic, soul) == blood)
            {
                bloodEssenceUIText.GetComponent<Blood_Essence_Quantity_Script>().ChangeQuantity(1);
            }
            else if (ChanceForDropComputed(blood, magic, soul) == magic)
            {            
                magicEssenceUIText.GetComponent<Magic_Essence_Quantity_Script>().changeQuantity(1);
            }
            else
            {
                Debug.Log("Error - Player_Item_Drop script ");
            }
        }
    }

    float ChanceForDropComputed(float blood, float magic, float soul)
    {
        return Mathf.Max(blood, magic, soul);
    }
    

}



