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

                // This feels very redundant to have two bools that accomplish
                // the same thing. In the future, this could be cleaned up by
                // removing requiresKey and only using unlocked.
                // For doors that do not require a key, just set their unlocked
                // bool value to true.
                if (requiresKey && !unlocked)
                {
                    if (key != null && key.GetComponent<Key>().isHeld) // Open Door
                    {
                        OpenDoor();
                        ChangeSpritesToUnlocked();
                        Destroy(key);
                        TeleportPlayer();
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

    void OpenDoor()
    {
        Door connect = connectedDoor.GetComponent<Door>();
        connect.unlocked = true;
        unlocked = true;
    }

    void ChangeSpritesToUnlocked()
    {
        Door connect = connectedDoor.GetComponent<Door>();
        spriteRenderer.sprite = unlockedSprite;
        connect.spriteRenderer.sprite = unlockedSprite;
    }
}
