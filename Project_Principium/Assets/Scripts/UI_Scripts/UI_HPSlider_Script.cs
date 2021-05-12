using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HPSlider_Script : MonoBehaviour
{
    Slider healthSliderUI;

    public void changeSliderHealth(float sliderValue)
    {
        healthSliderUI = gameObject.GetComponent<Slider>();
        healthSliderUI.value = sliderValue;
    }
}
