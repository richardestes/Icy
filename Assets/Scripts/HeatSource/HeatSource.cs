using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSource : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D _circleCollider;
    
    [SerializeField][Range(1f, 10f)]
    public float meltPower = 1f;

    [SerializeField]
    private GameObject player;

    private PlayerStats playerStats;

    void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
        meltPower = meltPower * 0.0001f;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!playerStats) return;
        if(collision.gameObject.tag == "Player")
        {
            print("Player in radius");
            playerStats.meltSpeed += meltPower;
            print("Player melt speed: " + playerStats.meltSpeed);
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!playerStats) return;
        if (collision.gameObject.tag == "Player")
        {
            playerStats.ResetMelt();
            print("Player has left radius");
            print("Player melt speed: " + playerStats.meltSpeed);
        }
    }
}
