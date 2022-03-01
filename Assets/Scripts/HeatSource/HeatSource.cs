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
        if (!player) player = GameObject.Find("Player");
        if (player) playerStats = player.GetComponent<PlayerStats>();
        meltPower = meltPower * 0.0001f; //conversion for simpler public field
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!playerStats) return;
        if(collision.gameObject.CompareTag("Player"))
        {
            print("You are melting!");
            playerStats.meltSpeed += meltPower;
            print("Player melt speed: " + playerStats.meltSpeed);
        }
    }
    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!playerStats) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStats.ResetMelt();
            print("You are no longer melting");
            print("Player melt speed: " + playerStats.meltSpeed);
        }
    }
}
