using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public Manager manager;
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.gameObject.name == "Player")
        {
            manager.HandleDeath();
        }
    }    
}
