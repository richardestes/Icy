using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject connectedDoor;
    public bool teleported = false;
    public GameObject key;

    public bool requiresKey;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetAxisRaw("Vertical") == 1 && !teleported) // up direction
            {
                if (requiresKey && key.GetComponent<Key>().isHeld)
                {
                    requiresKey = false;
                    TeleportPlayer();
                    Destroy(key);
                }
            }
        }
    }

    private void Update()
    {
        if(teleported && Input.GetAxisRaw("Vertical") < 1) // Did player let go of up direction
        {
            teleported = false;
        }
    }

    void TeleportPlayer()
    {
        player.transform.position = connectedDoor.transform.position;
        connectedDoor.GetComponent<Door>().teleported = true;
    }
}
