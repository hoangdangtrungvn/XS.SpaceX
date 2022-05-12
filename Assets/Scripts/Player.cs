using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 force;
    public float maxShootDelay;
    public float curShootDelay;
    public GameObject bulletObjA;
    public GameObject bulletObjB;
    public int bulletType;

    private bool isDragging;
    private float objWidth;
    private float objHeight;
    private Vector3 screenBounds;

    void Awake()
    {
        var objectSize = GetComponent<SpriteRenderer>().size;
        var coliderSize = gameObject.GetComponent<BoxCollider2D>().size;
        objWidth = (objectSize.x - coliderSize.x) / 2;
        objHeight = (objectSize.y + coliderSize.x) / 2;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
    }

    void Update()
    {
        Move();
        Fire();
    }

    void Move()
    {
        var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (isDragging)
        {
            direction.x = Mathf.Clamp(direction.x, -screenBounds.x + objWidth, screenBounds.x - objWidth);
            direction.y = Mathf.Clamp(direction.y, -screenBounds.y + objHeight, screenBounds.y - objHeight);

            transform.position = new Vector3(direction.x, direction.y, 0f);
        }
    }

    void OnMouseDrag()
    {
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Fire()
    {
        curShootDelay += Time.deltaTime;

        if (curShootDelay < maxShootDelay)
            return;

        switch (bulletType)
        {
            case 0:
                Instantiate(bulletObjA, transform.position, transform.rotation);
                break;
            case 1:
                Instantiate(bulletObjA, transform.position + Vector3.right * 0.1f, transform.rotation);
                Instantiate(bulletObjA, transform.position + Vector3.left * 0.1f, transform.rotation);
                break;
            case 2:
                Instantiate(bulletObjA, transform.position + Vector3.right * 0.25f, transform.rotation);
                Instantiate(bulletObjB, transform.position, transform.rotation);
                Instantiate(bulletObjA, transform.position + Vector3.left * 0.25f, transform.rotation);
                break;

        }

        curShootDelay = 0f;
    }
}
