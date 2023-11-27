using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultySlider : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dffcltyText;
    [SerializeField] Slider dffcltySlider;

    public void changeSettings()
    {
        if (dffcltySlider.value == 0)
        {
            dffcltyText.text = "easy\n\ntime counts down slower,\nleveling up is quicker";
            PlayerStats.Instance.drainHungerSpeed = 120;
            PlayerStats.Instance.drainHappySpeed = 240;
            PlayerStats.Instance.toLevel = 2;
            //Debug.Log("Changed difficulty to Easy");
        }
        else if (dffcltySlider.value == 1)
        {
            dffcltyText.text = "normal\n\ntime counts down steadily,\nit takes effort to level up";
            PlayerStats.Instance.drainHungerSpeed = 60;
            PlayerStats.Instance.drainHappySpeed = 120;
            PlayerStats.Instance.toLevel = 4;
            //Debug.Log("Changed difficulty to Normal");
        }
        else
        {
            dffcltyText.text = "hard\n\ntime counts down quickly,\nleveling up is a grind";
            PlayerStats.Instance.drainHungerSpeed = 30;
            PlayerStats.Instance.drainHappySpeed = 60;
            PlayerStats.Instance.toLevel = 6;
            //Debug.Log("Changed difficulty to Hard");
        }
    }
}
