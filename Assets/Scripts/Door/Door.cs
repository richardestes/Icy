using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject connectedDoor;
    public GameObject key;
    public bool requiresKey;

    [SerializeField]
    private Sprite lockedSprite;

    [SerializeField]
    private Sprite unlockedSprite;

    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private bool teleported = false;
    private bool unlocked = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (requiresKey || !unlocked)
        {
            spriteRenderer.sprite = lockedSprite;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Input.GetAxisRaw("Vertical") == 1 && !teleported) // up direction
            {
                if (unlocked) TeleportPlayer(); // less expensive so we check first

                if (requiresKey && !unlocked)
                {
                    if (key != null && key.GetComponent<Key>().isHeld) // Open Door
                    {
                        Door connect = connectedDoor.GetComponent<Door>();
                        connect.unlocked = true;
                        unlocked = true;
                        spriteRenderer.sprite = unlockedSprite;
                        connect.spriteRenderer.sprite = unlockedSprite;
                        Destroy(key);
                    }
                }
            }
        }
    }

    private void Update()
    {
        if (teleported && Input.GetAxisRaw("Vertical") < 1) // Did player let go of up direction
        {
            teleported = false;
        }
    }

    void TeleportPlayer()
    {
        Vector3 teleportPosition = connectedDoor.transform.position;
        teleportPosition.z = player.transform.position.z;
        player.transform.position = teleportPosition;
        connectedDoor.GetComponent<Door>().teleported = true;
    }
}
