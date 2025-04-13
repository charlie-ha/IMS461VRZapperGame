using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour
{
    [SerializeField] private TargetSpawner targetSpawner;
    private bool buttonPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PressButton()
    {
        if(buttonPressed == false)
        {
            targetSpawner.activateSpawner=true;//activate spawner
            buttonPressed = true;
        }
        else if (buttonPressed == true)
        {
            targetSpawner.activateSpawner=false;//deactivate spawner
            buttonPressed = false;
        }

    }

    
}
