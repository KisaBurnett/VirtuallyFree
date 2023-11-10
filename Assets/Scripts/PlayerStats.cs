using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;

    // Affected by difficulty settings
    public int drainHungerSpeed = 60;
    public int drainHappySpeed = 120;
    public int toLevel = 4;

    // Accessible player stats available to other classes
    public int hunger = 8;
    public int happiness = 8;
    public int hygiene = 8;
    public int level = 1;
    public int enemiesKilled = 0;

    public bool notPaused = false;
    public bool isDead = false;
    public bool isDepressed = false;

    // For restarting upon death, etc.
    int startStats = 8;
    int startLevel = 1;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        StartCoroutine(DrainHungerRoutine());
        StartCoroutine(DrainHappyRoutine());
    }

    public void ResetStats()
    {
        hunger = startStats;
        happiness = startStats;
        hygiene = startStats;
        level = startLevel;
        enemiesKilled = 0;
    }

    IEnumerator DrainHungerRoutine()
    {
        while (true)
        { 
            // Debug.Log("Hunger coroutine started!");
            yield return new WaitForSeconds(drainHungerSpeed);

            if (notPaused)
            {
                // Debug.Log("Draining hunger!");
                hunger -= 1;

                if (hunger <= 0)
                {
                    hunger = 0;
                    isDead = true;
                    //Debug.Log("I'm dead! x_x");
                    notPaused = false;
                    ResetStats();
                    SceneManager.LoadScene("DeathScene");
                }
            }
        }
    }

    IEnumerator DrainHappyRoutine()
    {
        while (true)
        {
            // Debug.Log("Happy coroutine started!");
            yield return new WaitForSeconds(drainHappySpeed);

            if (notPaused)
            {
                // Debug.Log("Draining happy!");
                if(hygiene <= 0)
                {
                    happiness -= 2;
                }
                else
                {
                    happiness -= 1;
                }

                if (happiness <= 0)
                {
                    happiness = 0;
                    isDepressed = true;
                    //Debug.Log("I'm depressed! ;_;");
                    notPaused = false;
                    ResetStats();
                    SceneManager.LoadScene("SadScene");
                }
            }
        }
    }
}
