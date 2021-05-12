using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player_Health : MonoBehaviour
{
    public float MaxHealth;
    private float Health;

    GameObject healthSliderUI;
    GameObject healthUI;

    void Start()
    {
        Health = MaxHealth;
        initializeUIObjects();
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        changeHealthInUI(Health, MaxHealth, Health/MaxHealth);
        if (Health <= 0)
        {
            Debug.Log("You Died!");
        }
    }

    void changeHealthInUI(float Health, float MaxHealth, float sliderValue)
    {
        healthUI.GetComponent<UI_HPNumber_Script>().changeHealth(Health, MaxHealth);
        healthSliderUI.GetComponent<UI_HPSlider_Script>().changeSliderHealth(sliderValue);
    }
    void initializeUIObjects()
    {
        healthUI = GameObject.Find("Current_Health_Number");
        healthUI.GetComponent<UI_HPNumber_Script>().changeHealth(Health, MaxHealth);

        healthSliderUI = GameObject.Find("Health_Bar_UI");
        healthSliderUI.GetComponent<UI_HPSlider_Script>().changeSliderHealth(1);
    }
}
