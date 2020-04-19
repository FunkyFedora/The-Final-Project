using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeed : MonoBehaviour
{
    public static float speed = -5;

    private Rigidbody rb;
    private static bool freeze = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            speed = -12;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            speed = -5;
        }

        if (Input.GetKeyDown(KeyCode.C) && freeze == true)
        {
            rb.isKinematic = true;
        }

        if(Input.GetKeyUp(KeyCode.C))
        {
            freeze = false;
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            freeze = true;
        }
    }
}
