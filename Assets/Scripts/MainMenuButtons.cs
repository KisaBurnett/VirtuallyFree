using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] TextMeshProUGUI instructionsText;
    [SerializeField] GameObject huntButton;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject endingsButton;

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
        instructionsText.text = "digi is a virtual pet living in a world where all the pets have been abandoned by their owners.\n\nyou must help digi maintain hunger, happiness, and hygiene levels by collecting food and eating, playing games, and taking baths.\n\ndigi's goal is to become strong enough to make it in this harsh, ownerless world alone. your help will make this possible.";
        instructionsPanel.SetActive(true);
    }

    // Read instructions for hunting.
    public void instructionsHuntPage()
    {
        instructionsText.text = "hunt to collect meat from other starving, now feral virtual pets.\n\neat the harvested meat in the home scene to raise the hunger meter, but be aware that cannibalism will make digi sad.\n\nuse wasd to move digi, and spacebar to swing the weapon. some enemies may require more strikes to slay.\n\ndon't forget to bathe digi after hunts, or digi's happiness will drain faster.";
        playButton.SetActive(true);
        huntButton.SetActive(false);
    }

    // Read instructions for playing.
    public void instructionsPlayPage()
    {
        instructionsText.text = "when the despair of the apocalypse brings digi's happiness too low, play a game to provide a spark of hope.\n\nuse w and d to move digi left and right to collect stars and avoid bones. a higher score will increase digi's happiness to a higher level.";
        endingsButton.SetActive(true);
        playButton.SetActive(false);
    }

    // Read instructions for endings.
    public void instructionsEndPage()
    {
        instructionsText.text = "an alert in the form of \"! ? !\" will appear on the home page if digi's hunger or happiness are too low. address digi's needs quickly, because a hunger or happiness level of 0 will end the game.\n\nlevel digi up enough to reveal a new option on the home page which will allow digi to begin a new life of freedom.";
        endingsButton.SetActive(false);
    }

    // Close instructions UI.
    public void CloseInstructions()
    {
        instructionsText.text = "digi is a virtual pet living in a world where all the pets have been abandoned by their owners.\n\nyou must help digi maintain hunger, happiness, and hygiene levels by collecting food and eating, playing games, and taking baths.\n\ndigi's goal is to become strong enough to make it in this harsh, ownerless world alone. your help will make this possible.";
        playButton.SetActive(false);
        endingsButton.SetActive(false);
        huntButton.SetActive(true);
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
