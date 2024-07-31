using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AngleThrowerManager : MonoBehaviour
{
    Rigidbody2D head;
    public float offset = 0.5f;
    public float force = 2;

    public Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        head = transform.GetComponentInChildren<Rigidbody2D>();    
        startPos = head.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(WaitTime(collision.gameObject));
        }
    }

    private IEnumerator WaitTime(GameObject obj)
    {
        yield return new WaitForEndOfFrame();
        
        Vector2 forceDir = -transform.up;
        Vector2 hitPos = new Vector2(head.position.x + offset, head.position.y);
        head.AddForceAtPosition(forceDir * force, hitPos, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.3f);
        ResetAncle();
    }

    private void ResetAncle()
    {
        head.transform.rotation = Quaternion.Euler(0, 0, -90);
        head.transform.position = startPos;
    }
}
