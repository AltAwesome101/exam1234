using UnityEngine;

public class movementtest : MonoBehaviour
{
    private Vector2 moveAmount;

    private Vector2 lastDirection = Vector2.down;

    [SerializeField] private float speed = 5f;

    [SerializeField] private Rigidbody2D m_RB;

    [SerializeField] private Transform lightmove;

    private Animator anim;

    private const string horizontal = "Horizontal";

    private const string vertical = "Vertical";

    private const string endHorizontal = "endHorizontal";

    private const string endVertical = "endVertical";

    void Start()
    {
        anim = GetComponent<Animator>();

        if (m_RB != null)
        {
            m_RB.gravityScale = 0f;

            m_RB.linearVelocity = Vector2.zero;
        }
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical)).normalized;

        moveAmount = moveInput * speed;

        anim.SetFloat(horizontal, moveAmount.x);
        anim.SetFloat(vertical, moveAmount.y);

        if (moveAmount != Vector2.zero)
        {
            anim.SetFloat(endHorizontal, moveAmount.x);
            anim.SetFloat(endVertical, moveAmount.y);
            lastDirection = moveInput;
            UpdateLightDirection(lastDirection);
        }
    }

    private void FixedUpdate()
    {
        if (m_RB != null)
        {
            m_RB.linearVelocity = Vector2.zero;

            m_RB.MovePosition(m_RB.position + moveAmount * Time.fixedDeltaTime);
        }
    }

    private void UpdateLightDirection(Vector2 direction)
    {
        if (direction == Vector2.left)
        {
            lightmove.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (direction == Vector2.right)
        {
            lightmove.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (direction == Vector2.down)
        {
            lightmove.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector2.up)
        {
            lightmove.rotation = Quaternion.Euler(0, 0, -180);
        }
    }
}
