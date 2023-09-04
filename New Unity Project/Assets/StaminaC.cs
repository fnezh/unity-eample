using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaC : MonoBehaviour
{
    public float maxStamina = 100f;
    public float stamina;

    public Slider staminaBar;
    public float dValue;

    public void Start()
    {
        maxStamina = stamina;
        staminaBar.maxValue = maxStamina;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            DecreaseEnergy();
        else if (stamina != maxStamina)
            IncreaseEnergy();

        staminaBar.value = stamina;
    }

    public void DecreaseEnergy()
    {
        if (stamina != 0)
            stamina -= dValue * Time.deltaTime;
    }

    public void IncreaseEnergy()
    {
    
        stamina += dValue * Time.deltaTime;
    }


}
