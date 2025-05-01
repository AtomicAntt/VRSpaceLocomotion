using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public AudioSource tutorialAudio;
    public bool tutorialEnded = false;

    public void EndTutorial()
    {
        print("function was called");
        if (!tutorialEnded)
        {
            print("if statement reached");
            tutorialEnded = true;
            tutorialAudio.Play();
            gameObject.SetActive(false);
        }
    }
}
