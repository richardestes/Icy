using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class HealingItem : Grabbable
{
    [SerializeField]
    private GameObject player;

    private PlayerStats playerStats;
    public override void Start()
    {
        base.Start(); // Create collider trigger and set default values
        if (!player) player = GameObject.Find("Player");
        playerStats = player.GetComponent<PlayerStats>();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        print("You got healed!");
        playerStats.Heal();
        Destroy(this.gameObject);
    }
}
