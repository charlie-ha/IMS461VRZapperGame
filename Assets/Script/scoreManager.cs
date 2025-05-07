using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class scoreManager : MonoBehaviour
{
    public int score = 0;
    public int redTargetBroken = 0;
    public int blueTargetBroken = 0;
    [SerializeField] private TMP_Text scoreText; // Drag your score UI TextMeshPro object here
    [SerializeField] private Text redTargetText;  
    [SerializeField] private Text blueTargetText; 
    
    public void AddScore(string targetTag)
    {
        if (targetTag == "redTarget")
        {
            score += 5;
            redTargetBroken += 1;
        }
        else if (targetTag == "blueTarget")
        {
            score += 10;
            blueTargetBroken += 1;
        }
        else if (targetTag == "movingBlueTarget")
        {
            score += 15;
            blueTargetBroken += 1;
        }
        else if (targetTag == "movingRedTarget")
        {
            score += 7;
            blueTargetBroken += 1;
        }

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text =   score.ToString();
            redTargetText.text = "- Red Targets Broken - " + redTargetBroken.ToString();
            blueTargetText.text = "- Blue Targets Broken - " + blueTargetBroken.ToString();
        }
    }

    public void ResetScore()
    {
        score = 0;
        redTargetBroken = 0;
        blueTargetBroken = 0;
        UpdateScoreText();
    }
}
