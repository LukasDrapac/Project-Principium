using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blood_Essence_Quantity_Script : MonoBehaviour
{
    private int essenceQuantity;
    

    void Awake()
    {
        essenceQuantity = 0;
        gameObject.GetComponent<Text>().text = essenceQuantity.ToString();
    }

    public void ChangeQuantity(int quantityDiference)
    {        
        essenceQuantity += quantityDiference;
        gameObject.GetComponent<Text>().text = essenceQuantity.ToString();
    }
}
