using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class TimerModeScoreManager : MonoBehaviour
{
    public int TM_score = 0;//TM_ stands for Timer Mode
    public int TM_redTargetBroken = 0;
    public int TM_blueTargetBroken = 0;
    [SerializeField] private TMP_Text scoreText; // Drag your score UI TextMeshPro object here
    [SerializeField] private Text redTargetText;
    [SerializeField] private Text blueTargetText;

    public void TM_AddScore(string targetTag)
    {
        if (targetTag == "TM_redTarget")
        {
            TM_score += 5;
            TM_redTargetBroken += 1;
        }
        else if (targetTag == "TM_blueTarget")
        {
            TM_score += 10;
            TM_blueTargetBroken += 1;
        }
        else if (targetTag == "TM_movingBlueTarget")
        {
            TM_score += 15;
            TM_blueTargetBroken += 1;
        }
        else if (targetTag == "TM_movingRedTarget")
        {
            TM_score += 7;
            TM_blueTargetBroken += 1;
        }

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = TM_score.ToString();
            redTargetText.text = "- Red Targets Broken - " + TM_redTargetBroken.ToString();
            blueTargetText.text = "- Blue Targets Broken - " + TM_blueTargetBroken.ToString();
        }
    }
    public void TM_ResetScore()
    {
        TM_score = 0;
        TM_redTargetBroken = 0;
        TM_blueTargetBroken = 0;
        UpdateScoreText();
    }
}
