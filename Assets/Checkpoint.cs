using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool tutorialCheckpoint = false;
    public TextMeshProUGUI tutorialText;
    public GameObject tutorialFire;
    public AudioSource tutorialAudio;

    public GameObject player;

    public void FixedUpdate()
    {
        if ((transform.position - player.transform.position).magnitude <= 2.0f && tutorialCheckpoint == true)
        {
            tutorialCheckpoint = false;
            tutorialFire.SetActive(true);
            tutorialAudio.Play();
            tutorialText.text = "TUTORIAL\n\n OH NO!\n\nThe checkpoint activator has set on fire!\n\nUse the fire extinguisher to take out the fire.";
        }
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        if (tutorialCheckpoint)
    //        {
    //            tutorialCheckpoint = false;
    //            tutorialFire.SetActive(true);
    //            tutorialText.text = "TUTORIAL\n\n OH NO!\n\nThe checkpoint activator has set on fire!\n\nUse the fire extinguisher to take out the fire.";
    //        }
    //    }
    //}
}
