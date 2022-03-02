using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private SpringJoint2D spring;

    public bool isHeld;

    void Start()
    {
        spring = GetComponent<SpringJoint2D>();
        spring.enabled = false;
        GameObject backpack = GameObject.FindWithTag("Backpack");
        spring.connectedBody = backpack.GetComponent<Rigidbody2D>();
        isHeld = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Add to backpack
        {
            spring.enabled = true;
            isHeld = true;
        }
    }
}
