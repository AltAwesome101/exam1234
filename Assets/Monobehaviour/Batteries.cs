using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] private BatteryPickupItem batteryData;

    private void OnTriggerEnter2D(Collider2D other)
    {  
        if (flashlightscript.Instance != null)
        {
            flashlightscript.Instance.AddBattery(batteryData.restoreAmount);
            Destroy(gameObject);
        }
    }
}
