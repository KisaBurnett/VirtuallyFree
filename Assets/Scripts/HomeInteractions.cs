using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HomeInteractions : MonoBehaviour
{
    [SerializeField] GameObject alertText;
    [SerializeField] GameObject digiBath;
    [SerializeField] GameObject digiIdle;
    [SerializeField] GameObject eatMenu;
    [SerializeField] GameObject escapeButton;
    [SerializeField] GameObject statsPanel;
    [SerializeField] TextMeshProUGUI tutorialText;

    [SerializeField] int alertNum;

    private void Update()
    {
        // Emergency alert behavior.
        if ((PlayerStats.Instance.hunger <= alertNum)
            || (PlayerStats.Instance.happiness <= alertNum)
            || (PlayerStats.Instance.hygiene <= alertNum))
        {
            alertText.SetActive(true);
            if (PlayerStats.Instance.completedAlertTutorial == false)
            {
                tutorialText.text = "An alert has triggered!\nQuick, check your stats to see what\'s wrong!";
                PlayerStats.Instance.completedAlertTutorial = true;
            }
        } else
        {
            alertText.SetActive(false);
        }
    }

    // Start the drain timer.
    public void Start()
    {
        if (PlayerStats.Instance.notPaused == false)
        {
            PlayerStats.Instance.notPaused = true;
        }

        if(PlayerStats.Instance.level >= 10)
        {
            escapeButton.SetActive(true);
        }
        else
        {
            escapeButton.SetActive(false);
        }
    }

    // PLACEHOLDER Bring up eating menu.
    public void EatFood()
    {
        // Should now go in the place where you click food: PlayerStats.Instance.hunger += 1;
        eatMenu.SetActive(true);
        tutorialText.text = " ";
    }

    // Close eating menu.
    public void CloseFood()
    {
        eatMenu.SetActive(false);
    }

    // PLACEHOLDER Bring up cleaning menu.
    public void CleanUp()
    {
        PlayerStats.Instance.hygiene = 8;
        tutorialText.text = " ";
        StartCoroutine(BathRoutine());
        //Debug.Log("I'm cleaning now!");
    }

    // Bring up the information UI.
    public void SeeInfo()
    {
        statsPanel.SetActive(true);
        if(PlayerStats.Instance.completedStatsTutorial == false)
        {
            tutorialText.text = "Use this to check your level and health.\nKeep a close eye on these meters!";
            PlayerStats.Instance.completedStatsTutorial = true;
        }
        else
        {
            tutorialText.text = " ";
        }
    }

    // Close information UI.
    public void CloseInfo()
    {
        tutorialText.text = " ";
        statsPanel.SetActive(false);
    }

    IEnumerator BathRoutine()
    {
        digiIdle.SetActive(false);
        digiBath.SetActive(true);

        yield return new WaitForSeconds(4);

        digiBath.SetActive(false);
        digiIdle.SetActive(true);
    }
}
