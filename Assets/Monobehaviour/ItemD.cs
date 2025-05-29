using TMPro;
using UnityEngine;
public class ItemQuantityDisplay : MonoBehaviour
{
    public Item itemToTrack;
    public TextMeshProUGUI quantityText;
    private void OnEnable()
    {
        if (itemToTrack != null)
        {
            itemToTrack.OnQuantityChanged += UpdateQuantityText;
            UpdateQuantityText(itemToTrack.quantity);
        }
    }
    private void OnDisable()
    {
        if (itemToTrack != null)
        {
            itemToTrack.OnQuantityChanged -= UpdateQuantityText;
        }
    }
    private void UpdateQuantityText(int quantity)
    {
        if (quantityText != null)
        {
            quantityText.text = $"Parts: {quantity}";
        }
    }
}