using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 1;
    public SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float hMov = Input.GetAxis("Horizontal");

        if (hMov > 0)
        {
            MoveRight();
        }
        else if (hMov < 0)
        {
            MoveLeft();
        }
    }

    void MoveRight()
    {
        sp.flipX = true;
        rb.AddForce(transform.right * speed);
    }
    void MoveLeft()
    {
        sp.flipX = false;
        rb.AddForce(-transform.right * speed);
    }
}
