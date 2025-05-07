using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TMbuttonPress : MonoBehaviour
{
    [SerializeField] private TargetSpawner targetSpawner;
    [SerializeField] private Text targetStatus;
    [SerializeField] private timer timerobj;
    //public scoreManager sManager;
    public TimerModeScoreManager TM_sManager;
    private bool buttonPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PressButton()
    {
        TM_sManager.TM_ResetScore();
        if (buttonPressed == false)
        {
            targetSpawner.activateSpawner=true;//activate spawner
            timerobj.timerIsOn = true;
            timerobj.remainingTime = 90;
            buttonPressed = true;
            targetStatus.text = "Target Spawning - True";
            
        }
        else if (buttonPressed == true)
        {
            targetSpawner.activateSpawner=false;//deactivate spawner
            buttonPressed = false;
            targetStatus.text = "Target Spawning - False";
        }

    }

    
}
