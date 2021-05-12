using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blood_Essence_Quantity_Script : MonoBehaviour
{
    private int essenceQuantity;
    Text uiText;

    void Awake()
    {
        essenceQuantity = 0;
        Debug.Log(essenceQuantity);
        gameObject.GetComponent<Text>().text = essenceQuantity.ToString();
    }

    public void changeQuantity(int quantityDiference)
    {
        setQuantity(quantityDiference);
    }

    void setQuantity(int quantityDiference)
    {
        essenceQuantity = essenceQuantity + quantityDiference;
        Debug.Log(essenceQuantity);
        gameObject.GetComponent<Text>().text = essenceQuantity.ToString();
    }
}
