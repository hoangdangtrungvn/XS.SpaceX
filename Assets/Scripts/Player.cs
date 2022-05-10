using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public bool isTouchTop;
    public bool isTouchRight;
    public bool isTouchBottom;
    public bool isTouchLeft;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && x == 1) || (isTouchLeft && x == -1))
            x = 0;
        var y = Input.GetAxisRaw("Vertical");
        if ((isTouchTop && y == 1) || (isTouchBottom && y == -1))
            y = 0;

        var curPos = transform.position;
        var nextPos = speed * Time.deltaTime * new Vector3(x, y, 0);

        transform.position = curPos + nextPos;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            animator.SetInteger("Input", (int)x);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;
                case "Left":
                    isTouchLeft = true;
                    break;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTouchTop = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
                case "Left":
                    isTouchLeft = false;
                    break;
            }
        }
    }
}
