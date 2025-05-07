using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class targetBreak : MonoBehaviour
{
    [SerializeField] private GameObject intact_target;
    [SerializeField] private GameObject broken_target;
    BoxCollider bc;
    private TargetSpawner targetSpawner;
    public bool timerMode = false;

    private void Awake()
    {
        targetSpawner = GameObject.Find("Spawner").GetComponent<TargetSpawner>();
        intact_target.SetActive(true);
        broken_target.SetActive(false);
        bc = GetComponent<BoxCollider>();
        //Debug.Log("awake");
    }
    public void Break()
    {
        intact_target.SetActive(false);
        broken_target.SetActive(true);
        //targetSpawner.targetsInGameAmount--;
        if(bc != null)
        {
            bc.enabled = false;
        }
        if(timerMode == false)
        {
            scoreManager scoreManager = GameObject.FindFirstObjectByType<scoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(this.tag);
            }
        }
        else //(timerMode == true)
        {
            TimerModeScoreManager timerModeScoreManager = GameObject.FindFirstObjectByType<TimerModeScoreManager>();
            if (timerModeScoreManager != null)
            {
                timerModeScoreManager.TM_AddScore(this.tag);
            }
        }

        //if (scoreManager != null)
        //{
        //    scoreManager.AddScore(this.tag);
        //}
        //if (TimerModeScoreManager != null)
        //{
        //    TimerModeScoreManager.AddScore(this.tag);
        //}
        //Debug.Log("broken");
    }
}
