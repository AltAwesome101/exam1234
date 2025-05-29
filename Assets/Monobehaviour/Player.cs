using UnityEngine;
using System.Collections;
using NUnit.Framework;
public class Player : Character1
{
    public HitPoints hitPoints;

    public HealthBar healthBarPrefab;

    public int amount;

    HealthBar healthBar;

    public RMInventory inventoryPrefab;

    RMInventory inventory;
    void Start()
    {
        hitPoints.value = startingHitPoints;

        inventory = Instantiate(inventoryPrefab);

        healthBar = Instantiate(healthBarPrefab);

        healthBar.character = this;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            if (hitObject != null)
            {
                bool shouldDisappear = false;

                switch (hitObject.itemType)   
                {
                    case Item.ItemType.PART: 
                        shouldDisappear = inventory.AddItem(hitObject);
                        shouldDisappear = true;
                        break;

                    case Item.ItemType.HEALTH: 
                        shouldDisappear = AdjustHitPoints(hitObject.quantity);
                        break;

                    default:
                        break;
                }

                if (shouldDisappear) 
                {
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }

    public bool AdjustHitPoints(int amount) 
    {
        if (hitPoints != null)
        {
            Debug.Log("Current HP before; " + hitPoints.value);
        }
        
        if (hitPoints.value < maxHitPoints)
        {
            hitPoints.value = hitPoints.value + amount;
            print("Adjusted HP by: " + amount + ".New value: " + hitPoints.value);
            return true;   
        }
        return false;
    }
    public override IEnumerator DamageCharacter(int damage, float inteval)
    {
        while (true) 
        {
            hitPoints.value = hitPoints.value - damage;

            if (hitPoints.value <= float.Epsilon) 
            {
                KillCharacter();
                break;
            }

            if (inteval > float.Epsilon) 
            {
                yield return new WaitForSeconds(inteval);
            }
            else 
            {
                yield return null;
                break;
            }
        }
    }
    public override void KillCharacter()
    {
        base.KillCharacter();

        if (healthBar != null)
            Destroy(healthBar.gameObject);

        if (inventory != null)
            Destroy(inventory.gameObject);

        if (RPGGameManager.sharedInstance != null)
        {
            RPGGameManager.sharedInstance.Invoke("SpawnPlayer", 0.0f);
        }

        Destroy(gameObject);
    }
    public override void ResetCharacter()
    {
        hitPoints.value = startingHitPoints;
        healthBar.gameObject.SetActive(true);
        inventory.gameObject.SetActive(true);
        healthBar.character = this;
    }
}