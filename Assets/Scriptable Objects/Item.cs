using UnityEngine;
using System;
public enum ItemType
{
    PART, HEALTH
}

[CreateAssetMenu(menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    public string objectName;
    public Sprite sprite;
    public bool stackable;
    public ItemType itemType;
    public enum ItemType
    {
        PART, HEALTH
    }

    [SerializeField]
    private int _quantity;
    public int quantity
    {
        get => _quantity;
        set
        {
            if (_quantity != value)
            {
                _quantity = value;
                OnQuantityChanged?.Invoke(_quantity);
            }
        }
    }
    public event Action<int> OnQuantityChanged;
}
