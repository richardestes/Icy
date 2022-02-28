using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class HeatSource : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D _circleCollider;
    
    [SerializeField][Range(0.001f, 0.01f)]
    public float meltPower = 0.001f;
    
    [SerializeField] 
    PlayerController player;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!player) return;
        if(collision.gameObject.tag == "Player")
        {
            print("Player in radius");
            player.meltSpeed += meltPower;
            print("Player melt speed: " + player.meltSpeed);
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!player) return;
        if (collision.gameObject.tag == "Player")
        {
            player.ResetMelt();
            print("Player has left radius");
            print("Player melt speed: " + player.meltSpeed);
        }
    }
}
