using System;
using System.Collections;
using System.Collections.Generic;
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

    public Transform xrCamera;

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
        print("Extinguisher Button Pushed");

        // Position 1 meter in front of the headset
        Vector3 spawnPosition = xrCamera.position + xrCamera.forward * 0.7f;
        Quaternion spawnRotation = extinguisher.transform.rotation; // face same direction

        Instantiate(extinguisher, spawnPosition, spawnRotation);
        spawnSound.Play();
        //print(activateActionValue.action.ReadValue<float>());
    }
}
