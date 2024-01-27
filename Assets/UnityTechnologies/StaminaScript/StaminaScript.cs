using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StaminaScript : MonoBehaviour
{
    public float stamina;
    float maxStamina;
    [SerializeField] 
   private Slider staminaBar;
    public float dValue;
    void Start()
    {
        maxStamina = stamina;
        staminaBar.value= stamina; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DecreaseEnergy();
        }
        else if(stamina!=maxStamina)
        {
            IncreaseEnergy();
        }
        staminaBar.value=stamina;
    }
    private void DecreaseEnergy()
    {
            if(stamina!=0)
        {
            stamina -= dValue * Time.deltaTime;
        }
    }
    private void IncreaseEnergy()
    {
        
      
            stamina += dValue * Time.deltaTime;
        
    }
}
