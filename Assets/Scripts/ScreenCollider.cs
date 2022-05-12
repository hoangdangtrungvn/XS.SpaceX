using UnityEngine;

public class ScreenCollider : MonoBehaviour
{
    public string tagName;
    public float paddingBottomLeft;
    public float paddingTopRight;
    public bool triggerCollider;
    public bool destroyOnCollide;

    private GameObject border;
    private GameObject top;
    private GameObject bottom;
    private GameObject left;
    private GameObject right;

    void Awake()
    {
        border = new GameObject(tagName);

        top = new GameObject("Top") { tag = tagName };
        top.transform.parent = border.transform;
        var rigid = top.AddComponent<Rigidbody2D>();
        rigid.bodyType = RigidbodyType2D.Kinematic;

        bottom = new GameObject("Bottom") { tag = tagName };
        bottom.transform.parent = border.transform;
        rigid = bottom.AddComponent<Rigidbody2D>();
        rigid.bodyType = RigidbodyType2D.Kinematic;

        left = new GameObject("Left") { tag = tagName };
        left.transform.parent = border.transform;
        rigid = left.AddComponent<Rigidbody2D>();
        rigid.bodyType = RigidbodyType2D.Kinematic;

        right = new GameObject("Right") { tag = tagName };
        right.transform.parent = border.transform;
        rigid = right.AddComponent<Rigidbody2D>();
        rigid.bodyType = RigidbodyType2D.Kinematic;
    }

    void Start()
    {
        CreateScreenColliders();
    }

    void CreateScreenColliders()
    {
        var bottomLeftScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(0f + paddingBottomLeft, 0f + paddingBottomLeft, 0f));
        var topRightScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width + paddingTopRight, Screen.height + paddingTopRight, 0f));


        // Create top collider
        var collider = top.AddComponent<BoxCollider2D>();
        collider.isTrigger = triggerCollider;
        collider.size = new Vector3(Mathf.Abs(bottomLeftScreenPoint.x - topRightScreenPoint.x), 0.1f, 0f);
        collider.offset = new Vector2(collider.size.x / 2f, collider.size.y / 2f);

        top.transform.position = new Vector3((bottomLeftScreenPoint.x - topRightScreenPoint.x) / 2f, topRightScreenPoint.y, 0f);


        // Create bottom collider
        collider = bottom.AddComponent<BoxCollider2D>();
        collider.isTrigger = triggerCollider;
        collider.size = new Vector3(Mathf.Abs(bottomLeftScreenPoint.x - topRightScreenPoint.x), 0.1f, 0f);
        collider.offset = new Vector2(collider.size.x / 2f, collider.size.y / 2f);

        //** Bottom needs to account for collider size
        bottom.transform.position = new Vector3((bottomLeftScreenPoint.x - topRightScreenPoint.x) / 2f, bottomLeftScreenPoint.y - collider.size.y, 0f);


        // Create left collider
        collider = left.AddComponent<BoxCollider2D>();
        collider.isTrigger = triggerCollider;
        collider.size = new Vector3(0.1f, Mathf.Abs(topRightScreenPoint.y - bottomLeftScreenPoint.y), 0f);
        collider.offset = new Vector2(collider.size.x / 2f, collider.size.y / 2f);

        //** Left needs to account for collider size
        left.transform.position = new Vector3(((bottomLeftScreenPoint.x - topRightScreenPoint.x) / 2f) - collider.size.x, bottomLeftScreenPoint.y, 0f);


        // Create right collider
        collider = right.AddComponent<BoxCollider2D>();
        collider.isTrigger = triggerCollider;
        collider.size = new Vector3(0.1f, Mathf.Abs(topRightScreenPoint.y - bottomLeftScreenPoint.y), 0f);
        collider.offset = new Vector2(collider.size.x / 2f, collider.size.y / 2f);

        right.transform.position = new Vector3(topRightScreenPoint.x, bottomLeftScreenPoint.y, 0f);
    }
}
