using UnityEngine;

public class ShootingItem : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public float unknown;
    void Start()
    {
        unknown = FindObjectOfType<HeroMove>().transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
        if (unknown < 0)
        {
            rb.velocity = transform.right * speed * (-1);
        }
        else if (unknown > 0)
            rb.velocity = transform.right * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("item"))
        {
            Destroy(gameObject);
        }

    }
}