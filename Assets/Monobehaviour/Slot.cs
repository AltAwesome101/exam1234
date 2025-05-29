using UnityEngine;
using TMPro;
public class Slot : MonoBehaviour
{
    public TextMeshProUGUI QtyText;

    void Awake()
    {
        if (QtyText == null)
        {
            QtyText = GetComponentInChildren<TextMeshProUGUI>();
            if (QtyText == null)
            {
                Debug.LogError($"Slot on '{gameObject.name}'no Text for this Bro");
            }
        }
    }
}

