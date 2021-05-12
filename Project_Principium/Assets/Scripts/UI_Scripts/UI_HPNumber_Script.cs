using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HPNumber_Script : MonoBehaviour
{
    Text currentHealthUIText;

    void Awake()
    {
        currentHealthUIText = gameObject.GetComponent<Text>();
    }

    public void changeHealth(float currentHealth, float maxHealth)
    {
        currentHealthUIText.text = currentHealth + "/" + maxHealth.ToString();
    }
}
