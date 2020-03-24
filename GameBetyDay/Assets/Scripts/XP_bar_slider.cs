using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XP_bar_slider : MonoBehaviour
{
        
    public Slider xPslider;

    public void SetMaxHealth(int xP)
    {
        
        xPslider.maxValue = xP;
        xPslider.value = xP;
    }

    public void SetHealth(int xP)
    {
        xPslider.value = xP;
    }
}
