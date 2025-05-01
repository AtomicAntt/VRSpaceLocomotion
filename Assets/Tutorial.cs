using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public AudioSource tutorialAudio;
    public GameObject tutorialFire;
    public bool tutorialEnded = false;

    public GameObject gameFires;

    public void EndTutorial()
    {
        if (!tutorialEnded && tutorialFire == null)
        {
            tutorialEnded = true;
            tutorialAudio.Play();

            foreach (Transform flame in gameFires.transform)
            {
                flame.gameObject.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}
