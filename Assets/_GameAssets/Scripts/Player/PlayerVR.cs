using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVR : MonoBehaviour
{
    private float energy = 1;
    public Slider sliderEnergy;
    public void DoDamage(float damage)
    {
        energy -= damage;
        sliderEnergy.value = energy;
    }
}
