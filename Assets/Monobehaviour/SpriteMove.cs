using UnityEngine;

public class SpriteDirectionController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    
    private Vector2 lastDirection = Vector2.right;

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (moveInput.x < 0)
        {
            lastDirection = Vector2.left;
            spriteRenderer.flipX = true;
        }
        else if (moveInput.x > 0)
        {
            lastDirection = Vector2.right;
            spriteRenderer.flipX = false;
        }  
    }
}