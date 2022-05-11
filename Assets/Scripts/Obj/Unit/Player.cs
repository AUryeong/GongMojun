using UnityEngine;

public class Player : Unit
{
    [Space(20f)]

    Animator animator;
    SpriteRenderer spriteRenderer;

    public float LastX = 0;
    public float JumpSpeed;
    public float LastY = 0;
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * JumpSpeed * 100);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Wind.Instance.ChangeDirection(Direction.Up);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                Wind.Instance.ChangeDirection(Direction.Down);
            }
            else
            {
                Direction dir;
                switch (Wind.Instance.direction)
                {
                    case Direction.Up:
                    case Direction.Down:
                        dir = direction;
                        break;
                    default:
                        dir = (Direction)(((int)Wind.Instance.direction + 1) % 2);
                        break;
                }
                Wind.Instance.ChangeDirection(dir);
            }
        }
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            LastX = rb.velocity.x;
            LastY = rb.velocity.y;
        }
    }

    protected void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * Spd);
            spriteRenderer.flipX = false;
            direction = Direction.Right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * Spd);
            spriteRenderer.flipX = true;
            direction = Direction.Left;
        }
        if ((Input.GetKey(KeyCode.D) && rb.velocity.x > 0.2f) || (Input.GetKey(KeyCode.A) && rb.velocity.x < -0.2f))
        {
            animator.SetBool("IsWalking", true);
            animator.speed = 1+ Mathf.Abs(rb.velocity.x) / 30;
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

}
