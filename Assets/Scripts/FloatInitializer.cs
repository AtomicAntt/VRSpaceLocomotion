using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatInitializer : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 randomDirection = Random.onUnitSphere;
        Vector3 forceVector = randomDirection * 0.1f;
        rb.AddForce(forceVector, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
