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
    public TimerModeScoreManager TM_sManager;
    private bool buttonPressed = false;
    //public bool buttonTimerMode = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PressButton()
    {
        TM_sManager.TM_ResetScore();
        Debug.Log("Reset");
        buttonPressed = !buttonPressed;

        if (buttonPressed == true)
        {
            targetSpawner.activateSpawner=true;//activate spawner
            //if (buttonTimerMode == true)
            //{
                timerobj.timerIsOn = true;
                timerobj.remainingTime = 90;
            //}
            
            buttonPressed = true;
            targetStatus.text = "Target Spawning - True";
            Debug.Log("TargetSpawn True");
        }
        else if (buttonPressed == false)
        {
            targetSpawner.activateSpawner=false;//deactivate spawner
            buttonPressed = false;
            targetStatus.text = "Target Spawning - False";
            Debug.Log("TargetSpawn False");
        }
        Debug.Log("Button Pressed");

    }

    
}
