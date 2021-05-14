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

    Player_Currency currencyScript;

    void Awake()
    {
        bloodEssenceUIText = GameObject.Find("Blood_Essence_Quantity");
        magicEssenceUIText = GameObject.Find("Magic_Essence_Quantity");
        soulEssenceUIText = GameObject.Find("Soul_Essence_Quantity");

        currencyScript = this.GetComponent<Player_Currency>();
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
                currencyScript.SetSoulEsseneQuantity(1);
                soulEssenceUIText.GetComponent<Soul_Essence_Quantity_Script>().ChangeQuantity(currencyScript.GetSoulEssenceQuantity());
            }
            else if (ChanceForDropComputed(blood, magic, soul) == blood)
            {
                currencyScript.SetBloodEssenceyQuantity(1);
                bloodEssenceUIText.GetComponent<Blood_Essence_Quantity_Script>().ChangeQuantity(currencyScript.GetBloodEssenceyQuantity());
            }
            else if (ChanceForDropComputed(blood, magic, soul) == magic)
            {
                currencyScript.SetMagicEssenceQuantity(1);
                magicEssenceUIText.GetComponent<Magic_Essence_Quantity_Script>().ChangeQuantity(currencyScript.GetMagicEssenceQuantity());
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



