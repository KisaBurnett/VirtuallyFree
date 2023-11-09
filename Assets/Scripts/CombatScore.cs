using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CombatScore : MonoBehaviour
{
    public bool waveOver = false;

    public GameObject digi;
    public GameObject endScreen;
    public GameObject spawner;

    public int playerHP;
    public int enemiesToKill;
    public int enemiesKilled = 0;
    
    public TextMeshProUGUI endText;
    public TextMeshProUGUI hpRemaining;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerStats.Instance.level < 5)
        {
            playerHP = 20;
        }
        else if (PlayerStats.Instance.level < 10)
        {
            playerHP = 30;
        }
        else
        {
            playerHP = 40;
        }
    }

    // Update is called once per frame
    void Update()
    {
        hpRemaining.text = playerHP.ToString();

        if(playerHP <= 0)
        {
            endText.text = "your kin ripped and tore you first!";
            spawner.SetActive(false);
            digi.SetActive(false);
            endScreen.SetActive(true);
        }

        if(enemiesKilled == enemiesToKill)
        {
            endText.text = "you shall feast on flesh tonight!";
            spawner.SetActive(false);
            digi.SetActive(false);
            endScreen.SetActive(true);
        }
    }
}
