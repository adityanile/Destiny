using System.Collections;
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
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(WaitTime(collision));
            collision.gameObject.SetActive(false);
        }
    }

    IEnumerator WaitTime(Collider2D collision)
    {
        yield return new WaitForSeconds(1);

        collision.gameObject.SetActive(true);

        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        collision.gameObject.transform.position = exit.transform.position;
        rb.velocity = Vector2.zero;

    }

}
