using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tutorialText;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerStats.Instance.completedHomeTutorial == false)
        {
            tutorialText.text = "your owner has been gone for so long...\nthey must be gone for good.\ntime to fend for yourself.\nclick \"stats\" to check your health.";
            PlayerStats.Instance.completedHomeTutorial = true;
        }
        else if((PlayerStats.Instance.completedHomeTutorial == true) && (PlayerStats.Instance.completedEatTutorial = false))
        {
            tutorialText.text = "great! you have collected meat!\ntry not to think about how you did it.\nclick \"eat\" to see what you have.\ndon\'t forget to take a bath!";
            PlayerStats.Instance.completedEatTutorial = true;
        }
        else if(PlayerStats.Instance.level == 10)
        {
            tutorialText.text = "what\'s this? a new menu option?\ndigi is now strong enough to fend for himself!\nhelp him escape from this confined nightmare!";
        }
        else
        {
            tutorialText.text = " ";
        }
    }
}
