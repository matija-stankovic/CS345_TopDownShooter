using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private int damage; 
    public Rigidbody2D rb;
    protected float speed;
    
    public void Initialize(Vector3 direction, int bulletDamage, float bulletSpeed)
    {
        rb = GetComponent<Rigidbody2D>();
        speed = bulletSpeed;
        damage = bulletDamage;
        transform.up = direction;
        StartCoroutine(StartCountdown());
    }
    
    private IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Decoration")
        {
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Player>() != null)
            {
                collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<Enemy>() != null)
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 9)
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }
}
