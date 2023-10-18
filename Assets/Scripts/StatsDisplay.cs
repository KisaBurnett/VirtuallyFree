using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Based on code by Blackthornprod on YouTube in their video:
// "HOW TO MAKE HEART/HEALTH SYSTEM - UNITY TUTORIAL"

public class StatsDisplay : MonoBehaviour
{
    [SerializeField] Image[] hungerBlocks;
    [SerializeField] Image[] happyBlocks;
    [SerializeField] Image[] hygieneBlocks;

    // Update is called once per frame
    void Update()
    {   
        for (int i = 0; i < hungerBlocks.Length; i++)
        {
            if(i < PlayerStats.Instance.hunger)
            {
                hungerBlocks[i].enabled = true;
            } else
            {
                hungerBlocks[i].enabled = false;
            }
        }

        for (int i = 0; i < happyBlocks.Length; i++)
        {
            if (i < PlayerStats.Instance.happiness)
            {
                happyBlocks[i].enabled = true;
            }
            else
            {
                happyBlocks[i].enabled = false;
            }
        }

        for (int i = 0; i < hygieneBlocks.Length; i++)
        {
            if (i < PlayerStats.Instance.hygiene)
            {
                hygieneBlocks[i].enabled = true;
            }
            else
            {
                hygieneBlocks[i].enabled = false;
            }
        }
    }
}