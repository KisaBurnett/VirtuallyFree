using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeInteractions : MonoBehaviour
{
    [SerializeField] GameObject statsPanel;
    [SerializeField] GameObject eatMenu;
    [SerializeField] GameObject alertText;

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
        if (!PlayerStats.Instance.notPaused)
        {
            PlayerStats.Instance.notPaused = true;
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
        Debug.Log("I'm cleaning now!");
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
}
