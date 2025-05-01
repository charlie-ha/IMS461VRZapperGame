using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class scoreManager : MonoBehaviour
{
    public int score = 0;
    [SerializeField] private Text scoreText; // Drag your score UI TextMeshPro object here

    public void AddScore(string targetTag)
    {
        if (targetTag == "redTarget")
        {
            score += 5;
        }
        else if (targetTag == "blueTarget")
        {
            score += 10;
        }

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
