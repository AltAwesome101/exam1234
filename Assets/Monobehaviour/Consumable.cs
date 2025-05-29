using UnityEngine;
using UnityEngine.UIElements;
public class Consumable : MonoBehaviour
{
    public Item item;

    public GameObject labelText;
    
    [SerializeField] AudioSource effect;

    public AudioClip collect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            effect.clip = collect;
            AudioSource.PlayClipAtPoint(collect, transform.position);

            RMInventory playerInventory = collision.GetComponent<RMInventory>();
            if (playerInventory != null)
            {
                playerInventory.AddItem(item);
            }

            if (labelText != null)
            {
                labelText.SetActive(false); 
            }
            Destroy(gameObject);
        }
    }
}

