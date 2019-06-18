using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ToggleSaver : MonoBehaviour
{
    private Toggle soundToggle;
    // Start is called before the first frame update
    void Start()
    {
        soundToggle = GetComponent<Toggle>();

        if(PlayerPrefs.GetInt("ToggleCheck") != 0)
        {
            if(PlayerPrefs.GetInt("ToggleCheck") == 1)
            {
                soundToggle.isOn = true;
            }
            else
            {
                soundToggle.isOn = false;
            }
        }
    }

    private void OnDisable()
    {
        if(soundToggle.isOn == true)
        {
            PlayerPrefs.SetInt("ToggleCheck", 1);
        }
        else
        {
            PlayerPrefs.SetInt("ToggleCheck", 2);
        }
    }

}
