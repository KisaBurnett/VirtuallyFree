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

    // Go to the Explore scene.
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
}