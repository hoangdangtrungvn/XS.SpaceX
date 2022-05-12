using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;

    void Update()
    {
        Move();
    }

    void Move()
    {
        var position = transform.position;
        transform.position = new Vector3(position.x, position.y + speed * Time.deltaTime, position.z);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
