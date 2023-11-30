using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HappinessIncreaser : MonoBehaviour
{
    public GameObject scoreCollector;
    public TextMeshProUGUI endMessage;
    float endScore;

    private void Start()
    {
        endMessage.text = " ";
        if(PlayerStats.Instance.toLevel == 4)
        {
            PlayerStats.Instance.happiness += 1;
        }
        else if(PlayerStats.Instance.toLevel == 6)
        {
            PlayerStats.Instance.happiness += 2;
        }
    }

    public void IncreaseHappiness()
    {
        endScore = scoreCollector.GetComponent<ScoreCollector>().score;

        if(endScore <= 0)
        {
            // Message is negative, happiness unchanged
            endMessage.text = "Oof, better luck next time.";
        }
        else if(endScore <= 5)
        {
            // Message is middling
            endMessage.text = "Well, it's better than nothing.";
            PlayerStats.Instance.happiness += 1;
        }
        else if(endScore <= 10)
        {
            // Message is a little happier
            endMessage.text = "Not great, but not bad!";
            PlayerStats.Instance.happiness += 2;
        }
        else if (endScore <= 15)
        {
            // Message is happy
            endMessage.text = "Good job! This will take the edge off!";
            PlayerStats.Instance.happiness += 3;
        }
        else if (endScore <= 20)
        {
            // Message is very happy
            endMessage.text = "Life isn't so bad after all!";
            PlayerStats.Instance.happiness += 4;
        }
        else if (endScore <= 25)
        {
            // Message is ecstatic
            endMessage.text = "The guilt of slaughtering kindred is gone!";
            PlayerStats.Instance.happiness += 5;
        }

        if(PlayerStats.Instance.happiness > 8)
        {
            PlayerStats.Instance.happiness = 8;
        }
    }
}
