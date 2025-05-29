using UnityEngine;

[CreateAssetMenu(menuName = "Pickup/Battery")]
public class BatteryPickupItem : ScriptableObject
{
    [Header("Battery Properties")]

    public string batteryName = "Battery";

    public Sprite sprite;

    [Tooltip("How much battery to restore when collected.")]

    public float restoreAmount = 25f;
}
