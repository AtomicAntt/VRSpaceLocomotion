using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : MonoBehaviour
{
    public GameObject[] threateningFires;
    public GameObject dialogue;

    private void FixedUpdate()
    {
        bool fireExists = false;
        foreach (GameObject fire in threateningFires)
        {
            if (fire != null)
            {
                fireExists = true;
            }
        }
        if (!fireExists)
        {
            dialogue.SetActive(true);
        }
    }
}
