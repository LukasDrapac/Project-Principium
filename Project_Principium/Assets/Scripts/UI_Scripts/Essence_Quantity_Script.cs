using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Essence_Quantity_Script : MonoBehaviour
{
    private int essenceQuantity;
    Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        uiText = gameObject.GetComponent<Text>();
        uiText.text = 0.ToString();
    }

    public void changeQuantity(int quantityDiference)
    {
        essenceQuantity += quantityDiference;
        uiText.text = essenceQuantity.ToString();
    }
}
