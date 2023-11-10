using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeInteractions : MonoBehaviour
{
    [SerializeField] GameObject alertText;
    [SerializeField] GameObject digiBath;
    [SerializeField] GameObject digiIdle;
    [SerializeField] GameObject eatMenu;
    [SerializeField] GameObject escapeButton;
    [SerializeField] GameObject statsPanel;

    [SerializeField] int alertNum;

    private void Update()
    {
        // Emergency alert behavior.
        if ((PlayerStats.Instance.hunger <= alertNum)
            || (PlayerStats.Instance.happiness <= alertNum)
            || (PlayerStats.Instance.hygiene <= alertNum))
        {
            alertText.SetActive(true);
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
    }

    // PLACEHOLDER Bring up eating menu.
    public void EatFood()
    {
        // Should now go in the place where you click food: PlayerStats.Instance.hunger += 1;
        eatMenu.SetActive(true);
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
        StartCoroutine(BathRoutine());
        //Debug.Log("I'm cleaning now!");
    }

    // Bring up the information UI.
    public void SeeInfo()
    {
        statsPanel.SetActive(true);
    }

    // Close information UI.
    public void CloseInfo()
    {
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
