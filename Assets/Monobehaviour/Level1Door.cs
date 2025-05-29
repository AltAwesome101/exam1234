using UnityEngine;
public class Level1Door : MonoBehaviour
{
    public Collider2D doorCollider;

    public SpriteRenderer doorSprite;

    private bool isOpen = false;
    void Start()
    {
        if (RPGGameManager.sharedInstance != null && RPGGameManager.sharedInstance.generatorStage >= 2) 
        {
            Open();
        }
    }
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

        Debug.Log("Level 1 Door Opened.");
    }
}