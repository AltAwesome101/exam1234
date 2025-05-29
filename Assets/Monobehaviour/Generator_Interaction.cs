using UnityEngine;
using TMPro;

public class Generator_Interaction : MonoBehaviour, IInteractable
{
    public RMInventory playerInventory;
    public Item requiredPart;
    public int[] partsRequiredPerStage = { 8, 24, 48 };
    private int currentStage = 0;
    public TextMeshProUGUI uiText;
    public GameObject winnerScreen;
    public Door[] doorsToOpenPerStage;
    private bool fullyRepaired = false;

    [SerializeField] AudioSource effect;

    public AudioClip fix;

    private static Generator_Interaction instance;

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
        }
    }

    public void PlayerInteraction()
    {
        if (playerInventory == null || requiredPart == null)
        {
            Debug.LogError("Generator_Interaction: Don't have the required parts");
            return;
        }

        if (fullyRepaired)
        {
            uiText.text = "Generator fully repaired!";
            return;
        }

        int requiredCount = partsRequiredPerStage[currentStage];
        int count = playerInventory.GetQuantity(requiredPart);

        if (count >= requiredCount)
        {
            effect.clip = fix;
            effect.Play();
            playerInventory.RemoveItem(requiredPart, requiredCount);
            uiText.text = $"Stage {currentStage} repair complete!";
            OpenDoorForStage(currentStage);

            currentStage++;

            if (RPGGameManager.sharedInstance != null)
            {
                RPGGameManager.sharedInstance.generatorStage = currentStage;
            }

            if (currentStage >= partsRequiredPerStage.Length)
            {
                fullyRepaired = true;
                ShowWinnerScreen();
            }

            RefreshItemUI();
        }
        else
        {
            uiText.text = $"{requiredCount} parts are required to fix generator Stage {currentStage}.\n({count}/{requiredCount} collected)";
        }
    }

    public bool CanInteract()
    {
        return !fullyRepaired;
    }

    private void OpenDoorForStage(int stage)
    {
        if (stage < doorsToOpenPerStage.Length && doorsToOpenPerStage[stage] != null)
        {
            doorsToOpenPerStage[stage].Open();
        }
    }

    private void ShowWinnerScreen()
    {
        if (winnerScreen != null)
        {
            winnerScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Make a Winner Screen Before You Forget!");
        }
    }

    private void RefreshItemUI()
    {
        ItemUIUpdater updater = FindObjectOfType<ItemUIUpdater>();
        if (updater != null)
        {
            updater.RefreshDisplay();
        }
    }

    public int GetCurrentStage()
    {
        return currentStage;
    }

    public int[] GetPartsRequiredPerStage()
    {
        return partsRequiredPerStage;
    }

    public static Generator_Interaction GetInstance()
    {
        return instance;
    }
}
