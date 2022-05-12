using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;
    public Sprite[] sprites;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        var position = transform.position;
        transform.position = new Vector3(position.x, position.y - speed * Time.deltaTime, position.z);
    }

    void OnHit(int damage)
    {
        health -= damage;

        spriteRenderer.sprite = sprites[1];
        Invoke(nameof(SetDefaultSprite), 0.1f);

        if (health <= 0)
            Destroy(gameObject);
    }

    void SetDefaultSprite()
    {
        spriteRenderer.sprite = sprites[0];
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            var bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.damage);
        }
    }
}
