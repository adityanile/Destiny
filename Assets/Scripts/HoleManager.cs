using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    GameObject parent;
    public Transform exit;

    private void Start()
    {
        parent = transform.parent.gameObject;
        exit = parent.transform.GetChild(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb  = collision.GetComponent<Rigidbody2D>();
        collision.gameObject.transform.position = exit.transform.position;

        rb.velocity = Vector2.zero;
    }

}
