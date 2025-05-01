using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class HandMenuScript : MonoBehaviour
{
    public Button extinguisherButton;
    public Button checkpointButton;
    public InputActionProperty activateActionValue;

    public GameObject panel;

    public GameObject extinguisher;
    public AudioSource spawnSound;

    public TextMeshProUGUI tutorialText;
    public GameObject tutorialFire;

    public Transform xrCamera;

    private bool pressed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = activateActionValue.action.ReadValue<float>();
        panel.SetActive(triggerValue > 0.1f);

    }

    public void ExtinguisherButtonPushed()
    {
        if (!pressed)
        {
            tutorialText.text = "TUTORIAL\n\nNow, grab that fire extinguisher and propel yourself to the checkpoint area!\n\nYou will be propelled away from the direction you shoot.";
            //tutorialFire.SetActive(true);
        }

        pressed = true;

        Vector3 spawnPosition = xrCamera.position + xrCamera.forward * 0.7f;
        Quaternion spawnRotation = extinguisher.transform.rotation; 

        Instantiate(extinguisher, spawnPosition, spawnRotation);
        spawnSound.Play();
    }
}
