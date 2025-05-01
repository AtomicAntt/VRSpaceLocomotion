using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public bool tutorialFire = false;
    public TextMeshProUGUI tutorialText;
    public AudioSource tutorialAudioSource;
    
    public void Extinguish()
    {
        if (tutorialFire)
        {
            tutorialAudioSource.Play();
            tutorialText.text = "TUTORIAL\n\nCongratulations, you've extinguished the fire!\n\nNow push the button to end the tutorial and set the checkpoint.";
        }
        Destroy(gameObject);
    }
}
