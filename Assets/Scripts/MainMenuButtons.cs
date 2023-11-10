using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject settingsPanel;

    // Pause the drain timer.
    public void Start()
    {
        if (PlayerStats.Instance.notPaused == true)
        {
            PlayerStats.Instance.notPaused = false;
        }
    }
    
    // Start the game by routing player to the Home scene.
    public void StartGame()
    {
        SceneManager.LoadScene("HomeScene");
    }

    // Bring up the instructions UI.
    public void ReadInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    // Close instructions UI.
    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    // Bring up settings UI.
    public void ConfigureSettings()
    {
        settingsPanel.SetActive(true);
    }

    // Close settings UI.
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    // Quit the game.
    public void QuitGame()
    {
        Application.Quit();
    }
}
