using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class buttonPress : MonoBehaviour
{
    [SerializeField] private TargetSpawner targetSpawner;
    [SerializeField] private Text targetStatus;
    [SerializeField] private timer timerobj;
    public scoreManager sManager;
    private bool buttonPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PressButton()
    {
        if(buttonPressed == false)
        {
            targetSpawner.activateSpawner=true;//activate spawner
            timerobj.timerIsOn = true;
            timerobj.remainingTime = 90;
            buttonPressed = true;
            targetStatus.text = "Target Spawning - True";
            sManager.score = 0;
        }
        else if (buttonPressed == true)
        {
            targetSpawner.activateSpawner=false;//deactivate spawner
            buttonPressed = false;
            targetStatus.text = "Target Spawning - False";
        }

    }

    
}
