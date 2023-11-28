// Based on code by The Game Guy on YouTube
// in the video How to Create a Simple Countdown Timer in Unity | #shorts
// https://www.youtube.com/watch?v=hxpUk0qiRGs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] float timeRemaining;

    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject spawner;

    [SerializeField] TextMeshProUGUI notification;

    public bool timerOn = false;

    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        gameOver.SetActive(false);
        spawner.GetComponent<ProjectileSpawner>().gameOver = false;

        if(PlayerStats.Instance.completedPlayTutorial == false)
        {
            StartCoroutine(TutorialFlash());
            PlayerStats.Instance.completedPlayTutorial = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimer(timeRemaining);
            } else
            {
                timeRemaining = 0;
                timerOn = false;
                gameOver.SetActive(true);
                spawner.GetComponent<ProjectileSpawner>().gameOver = true;
                gameOver.GetComponent<HappinessIncreaser>().IncreaseHappiness();
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator TutorialFlash()
    {
        notification.text = "use a and d to move digi\ncollect stars, but avoid bones";

        yield return new WaitForSeconds(10);

        notification.text = " ";
    }
}
