using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;

public class Grabbable : MonoBehaviour
{
    public CircleCollider2D collider;

    [SerializeField][Range(0.5f,3f)]
    private float pickupRadius;

    public virtual void Start()
    {
        collider = this.gameObject.AddComponent<CircleCollider2D>();
        if (collider) SetDefaultValues();
    }

    void SetDefaultValues()
    {        
        collider.isTrigger = true;
        if (pickupRadius < 0.1f)
        {
            collider.radius = 1f;
        }
        else collider.radius = pickupRadius;

    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Player in grab radius");
        }
    }

    public virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Player out of grab radius");
        }
    }
}
