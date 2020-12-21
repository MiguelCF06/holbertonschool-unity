﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1000f;
    public int health = 5;
    private int score = 0;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rigidbody.AddForce(0, 0, speed * Time.deltaTime);
        }

        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            rigidbody.AddForce(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rigidbody.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rigidbody.AddForce(speed * Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            score += 1;
            Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        }

        if (other.tag == "Trap")
        {
            health -= 1;
            Debug.Log($"Health: {health}");
        }
    }
}
