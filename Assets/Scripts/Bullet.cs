using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    [SerializeField] private int damage; 
    private string targetTag = "Enemy"; 
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == targetTag)
        {
            if (other.gameObject.GetComponent<Enemy>() != null)
            {
                other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
