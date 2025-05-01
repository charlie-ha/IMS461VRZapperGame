using UnityEngine;
using TMPro;
public class timer : MonoBehaviour
{
    public bool timerIsOn;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        timerIsOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsOn)
        {
            remainingTime -= Time.deltaTime;
            int minuets = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minuets, seconds);
            if(seconds < 0 && minuets < 0)
            {
                timerIsOn=false;
            }
        }
        
    }
}
