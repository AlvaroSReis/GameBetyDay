using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_bar_slider : MonoBehaviour
{
    
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        if((slider.value - health)>= 20)
        {
            slider.value = health;
        }else{
            slider.value = 20;
        }
    }
}
