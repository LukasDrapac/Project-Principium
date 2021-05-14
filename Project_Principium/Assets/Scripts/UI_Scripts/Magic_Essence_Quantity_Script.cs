using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class Magic_Essence_Quantity_Script : MonoBehaviour
{
    void Awake()
    {
        this.GetComponent<Text>().text = 0.ToString();
    }

    public void ChangeQuantity(int newQuantity)
    {
        this.GetComponent<Text>().text = newQuantity.ToString();
    }
}
