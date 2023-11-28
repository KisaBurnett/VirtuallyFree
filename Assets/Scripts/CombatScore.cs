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
    public TextMeshProUGUI notification;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerStats.Instance.completedHuntTutorial == false)
        {
            StartCoroutine(TutorialFlash());
        }
        
        if(PlayerStats.Instance.level < 2)
        {
            playerHP = 20;
        }
        else if (PlayerStats.Instance.level < 5)
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
            endScreen.SetActive(true);
        }
    }

    public void LevelUp()
    {
        StartCoroutine(MessageFlash());
    }

    IEnumerator MessageFlash()
    {
        notification.text = "You leveled up!";

        yield return new WaitForSeconds(5);

        notification.text = " ";
    }

    IEnumerator TutorialFlash()
    {
        notification.text = "these pets have been without owners so long they've gone feral!\nkill them before they kill you!";

        yield return new WaitForSeconds(5);

        PlayerStats.Instance.completedHuntTutorial = true;

        notification.text = "use wasd to move digi\npress spacebar to swing weapon";

        yield return new WaitForSeconds(5);

        notification.text = " ";
    }
}
