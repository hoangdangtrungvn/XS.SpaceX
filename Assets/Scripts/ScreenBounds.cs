using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    public float padding = 1;

    private Vector3 bounds;

    void Awake()
    {
        bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
    }

    void Update()
    {
        var position = transform.position;

        if (position.x < -bounds.x - padding ||
            position.x > bounds.x + padding ||
            position.y < -bounds.y - padding ||
            position.y > bounds.y + padding)
        {
            Destroy(gameObject);
        }
    }
}
