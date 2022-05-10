using UnityEngine;

public class ScreenCollider : MonoBehaviour
{
    GameObject border;
    GameObject top;
    GameObject bottom;
    GameObject left;
    GameObject right;

    void Awake()
    {
        border = new GameObject("Border");

        top = new GameObject("Top") { tag = "Border" };
        top.transform.parent = border.transform;

        bottom = new GameObject("Bottom") { tag = "Border" };
        bottom.transform.parent = border.transform;

        left = new GameObject("Left") { tag = "Border" };
        left.transform.parent = border.transform;

        right = new GameObject("Right") { tag = "Border" };
        right.transform.parent = border.transform;
    }

    void Start()
    {
        CreateScreenColliders();
    }

    void CreateScreenColliders()
    {
        var bottomLeftScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 0f));
        var topRightScreenPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));


        // Create top collider
        var collider = top.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.size = new Vector3(Mathf.Abs(bottomLeftScreenPoint.x - topRightScreenPoint.x), 0.1f, 0f);
        collider.offset = new Vector2(collider.size.x / 2f, collider.size.y / 2f);

        top.transform.position = new Vector3((bottomLeftScreenPoint.x - topRightScreenPoint.x) / 2f, topRightScreenPoint.y, 0f);


        // Create bottom collider
        collider = bottom.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.size = new Vector3(Mathf.Abs(bottomLeftScreenPoint.x - topRightScreenPoint.x), 0.1f, 0f);
        collider.offset = new Vector2(collider.size.x / 2f, collider.size.y / 2f);

        //** Bottom needs to account for collider size
        bottom.transform.position = new Vector3((bottomLeftScreenPoint.x - topRightScreenPoint.x) / 2f, bottomLeftScreenPoint.y - collider.size.y, 0f);


        // Create left collider
        collider = left.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.size = new Vector3(0.1f, Mathf.Abs(topRightScreenPoint.y - bottomLeftScreenPoint.y), 0f);
        collider.offset = new Vector2(collider.size.x / 2f, collider.size.y / 2f);

        //** Left needs to account for collider size
        left.transform.position = new Vector3(((bottomLeftScreenPoint.x - topRightScreenPoint.x) / 2f) - collider.size.x, bottomLeftScreenPoint.y, 0f);


        // Create right collider
        collider = right.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.size = new Vector3(0.1f, Mathf.Abs(topRightScreenPoint.y - bottomLeftScreenPoint.y), 0f);
        collider.offset = new Vector2(collider.size.x / 2f, collider.size.y / 2f);

        right.transform.position = new Vector3(topRightScreenPoint.x, bottomLeftScreenPoint.y, 0f);
    }
}
