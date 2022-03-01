using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class HealingItem : Grabbable
{
    private PlayerStats playerStats;
    public override void Start()
    {
        base.Start(); // Create collider trigger and set default values
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        print("This is a healing item!");
        playerStats.Heal();
        Destroy(this.gameObject);
    }
}
