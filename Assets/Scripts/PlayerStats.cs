using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance;
    
    public int hunger = 8;
    public int happiness = 8;
    public int hygiene = 8;
    [SerializeField] int drainHungerSpeed = 60;
    [SerializeField] int drainHappySpeed = 120;
    public int level = 1;

    public bool notPaused = false;
    public bool isDead = false;
    public bool isDepressed = false;

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
                    Debug.Log("I'm dead! x_x");
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
                happiness -= 1;

                if (happiness <= 0)
                {
                    happiness = 0;
                    isDepressed = true;
                    Debug.Log("I'm depressed! ;_;");
                }
            }
        }
    }
}
