using UnityEngine;
public class Door : MonoBehaviour
{
    public Collider2D doorCollider;

    public SpriteRenderer doorSprite;

    private bool isOpen = false;
    public void Open()
    {
        if (isOpen) 
        {
            return;
        }
        isOpen = true;
        if (doorCollider != null)
        {
            doorCollider.enabled = false;
        }
        if (doorSprite != null)
        {
            doorSprite.enabled = false;
        }
        Debug.Log("Door is now open (collider and renderer disabled).");
    }
}



