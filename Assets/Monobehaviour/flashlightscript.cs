//Title: C# in Depth
//Auther: Joe Sloeet
//Date: January 7th 2006
//Code Version : N/A
//Availability : https://csharpindepth.com/articles/singleton

using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class flashlightscript : MonoBehaviour
{
    public static flashlightscript Instance { get; private set; } // Singleton

    [Header("Flashlight Components")]

    [SerializeField] private Light2D lightFlash;

    [SerializeField] private Material shaderMaterial;

    [SerializeField] private float maxDepth = 1f;

    [SerializeField] private float minDepth = 0f;

    [Header("Battery Settings")]

    [SerializeField] private float batteryMax = 100f;

    [SerializeField] private float batteryDrainRate = 0.5f;

    private float currentBattery;

    [Header("UI")]

    [SerializeField] private Image batteryBarImage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentBattery = batteryMax;
        UpdateBatteryBar();
    }

    private void Update()
    {
        HandleFlashlightToggle();
        HandleBatteryDrain();
        UpdateBatteryBar();
    }

    private void HandleFlashlightToggle()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (!lightFlash.enabled && currentBattery > 0f)
            {
                lightFlash.enabled = true;
                shaderMaterial.SetFloat("_Depth", minDepth);
            }
            else if (lightFlash.enabled)
            {
                lightFlash.enabled = false;
                shaderMaterial.SetFloat("_Depth", maxDepth);
            }
        }
    }

    private void HandleBatteryDrain()
    {
        if (lightFlash.enabled && currentBattery > 0f)
        {
            currentBattery -= batteryDrainRate * Time.deltaTime;

            if (currentBattery <= 0f)
            {
                currentBattery = 0f;
                lightFlash.enabled = false;
                shaderMaterial.SetFloat("_Depth", maxDepth);
            }
        }
    }

    public void AddBattery(float amount)
    {
        currentBattery = Mathf.Clamp(currentBattery + amount, 0f, batteryMax);
        UpdateBatteryBar();
    }

    private void UpdateBatteryBar()
    {
        if (batteryBarImage != null)
        {
            float normalizedFill = Mathf.Clamp01(currentBattery / batteryMax);
            batteryBarImage.fillAmount = normalizedFill;  
        }       
    }
}
