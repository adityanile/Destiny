using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringManager : MonoBehaviour
{
    public Rigidbody2D rb;
    public float force = 2;

    private GameObject head;
    private Vector3 startPos;


    private void Start()
    {
        head = transform.GetChild(0).gameObject;
        startPos = head.transform.localPosition;

        rb = head.GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (gameObject.CompareTag("WaitSpring"))
                StartCoroutine(WaitTime(collision.gameObject));
            else
                Instant(collision.gameObject);
        }
    }

    private IEnumerator WaitTime(GameObject obj)
    {
        yield return new WaitForSeconds(0.5f);

        rb.AddForce(head.transform.up * force, ForceMode2D.Impulse);
        obj.GetComponent<Rigidbody2D>().AddForce(head.transform.up * force, ForceMode2D.Impulse);

        StartCoroutine(ResetSpring());
    }

    void Instant(GameObject obj)
    {
        rb.AddForce(head.transform.up * force, ForceMode2D.Impulse);
        obj.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up, ForceMode2D.Impulse);

        StartCoroutine(ResetSpring());
    }



    public IEnumerator ResetSpring()
    {
        yield return new WaitForSeconds(0.5f);
        head.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        head.transform.localPosition = startPos;
    }

}
