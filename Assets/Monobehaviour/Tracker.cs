using UnityEngine;
using TMPro;

public class ItemUIUpdater : MonoBehaviour
{
    public Item trackedItem;
    public TextMeshProUGUI quantityText;

    public Generator_Interaction generator;

    private static ItemUIUpdater instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        if (trackedItem != null)
        {
            trackedItem.OnQuantityChanged += UpdateQuantityDisplay;
            UpdateQuantityDisplay(trackedItem.quantity);
        }
    }

    private void OnDisable()
    {
        if (trackedItem != null)
        {
            trackedItem.OnQuantityChanged -= UpdateQuantityDisplay;
        }
    }

    private void UpdateQuantityDisplay(int quantity)
    {
        if (quantityText != null)
        {
            int required = 0;
            if (generator != null && generator.CanInteract())
            {
                int stage = generator.GetCurrentStage();
                int[] requirements = generator.GetPartsRequiredPerStage();
                if (stage < requirements.Length)
                {
                    required = requirements[stage];
                }
            }
            quantityText.text = $"Parts: {quantity} / {required}";
        }
    }

    public void RefreshDisplay()
    {
        if (quantityText != null && trackedItem != null)
        {
            int quantity = trackedItem.quantity;
            Generator_Interaction generator = Generator_Interaction.GetInstance();
            if (generator != null)
            {
                int stage = generator.GetCurrentStage();
                int[] required = generator.GetPartsRequiredPerStage();
                if (stage < required.Length)
                {
                    quantityText.text = $"Parts: {quantity} / {required[stage]}";
                    return;
                }
            }

            quantityText.text = $"Parts: {quantity}";
        }
    }
}
