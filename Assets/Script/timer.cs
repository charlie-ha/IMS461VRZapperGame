using UnityEngine;
using TMPro;
public class timer : MonoBehaviour
{
    [SerializeField] private int targetLayer = 6;
    [SerializeField] private TargetSpawner targetSpawner;
    public bool timerIsOn;
    [SerializeField] TextMeshProUGUI timerText;
     public float remainingTime;
    [SerializeField] string[] targetTags;

    [SerializeField] private AudioClip endSound;
    private AudioSource audioSource;

    [SerializeField] private AudioClip countdownSound;
    private bool countdownSoundPlayed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        timerIsOn = false;
        audioSource = GetComponent<AudioSource>();
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
            if (remainingTime <= 60 && remainingTime > 40)//increase spawn rate and number
            {
                targetSpawner.targetSpawnAmount = 8;
                targetSpawner.spawnTimer = 8f;
            }
            else if (remainingTime <= 40 && remainingTime > 20)
            {
                targetSpawner.targetSpawnAmount = 12;
                targetSpawner.spawnTimer = 6f;
            }
            else if (remainingTime <= 20)
            {
                targetSpawner.targetSpawnAmount = 15;
                targetSpawner.spawnTimer = 4f;
            }

            if (remainingTime <= 30f && !countdownSoundPlayed)//calls once instead of every frame
            {

                audioSource.clip = countdownSound;
                audioSource.loop = true;
                audioSource.Play();
                countdownSoundPlayed = true;
                Debug.Log("Countdown Sound Played");
            }
            if (seconds <= 0 && minuets <= 0)
            {
                timerIsOn=false;
                //turn off spawn
                targetSpawner.activateSpawner = false;
                DestroyObjectsWithTags(targetTags);
                countdownSoundPlayed = false;
                targetSpawner.targetSpawnAmount = 5;
                targetSpawner.spawnTimer = 10f;
                if (audioSource.isPlaying)
                {
                    audioSource.Stop(); // Stop ticking
                    audioSource.loop = false;
                }
                audioSource.PlayOneShot(endSound);

            }
        }

        
    }
    private void DestroyObjectsWithTags(string[] tags)
    {
        int count = 0;
        foreach (string tag in tags)
        {
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in taggedObjects)
            {
                Destroy(obj);
                count++;
            }
        }

        Debug.Log($"Destroyed {count} objects with tags: {string.Join(", ", tags)}");
    }
}
