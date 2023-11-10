using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Go to Home scene.
    public void GoHome()
    {
        SceneManager.LoadScene("HomeScene");
    }

    // Go to the Playtime scene.
    public void GoPlay()
    {
        SceneManager.LoadScene("PlaytimeScene");
    }

    // Go to the Explore scene and escape the game.
    public void GoExplore()
    {
        SceneManager.LoadScene("ExploreScene");
    }

    // Go to the Combat scene.
    public void GoHunt()
    {
        SceneManager.LoadScene("CombatScene");
    }

    // Go to the Main Menu
    public void GoMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Go Home from hunting.
    public void ReturnHunt()
    {
        PlayerStats.Instance.hygiene -= 3;

        if(PlayerStats.Instance.hygiene < 0)
        {
            PlayerStats.Instance.hygiene = 0;
        }

        GoHome();
    }
}
