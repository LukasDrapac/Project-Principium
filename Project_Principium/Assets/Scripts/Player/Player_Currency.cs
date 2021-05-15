using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Currency : MonoBehaviour
{
    private int bloodEssenceQuantity;
    private int magicEssenceQuantity;
    private int soulEssenceQuantity;

    void Start(){
        bloodEssenceQuantity = 0;
        magicEssenceQuantity = 0;
        soulEssenceQuantity = 0;
    }
    public void SetBloodEssenceyQuantity(int quantityDiference){
        bloodEssenceQuantity += quantityDiference;
    }


    public void SetSoulEsseneQuantity(int quantityDiference){
        soulEssenceQuantity += quantityDiference;
    }

    public void SetMagicEssenceQuantity(int quantityDiference){
        magicEssenceQuantity += quantityDiference;
    }


    public int GetBloodEssenceyQuantity(){
        return bloodEssenceQuantity;
    }

    public int GetSoulEssenceQuantity(){
        return soulEssenceQuantity;
    }

    public int GetMagicEssenceQuantity(){
        return magicEssenceQuantity;
    }

}
