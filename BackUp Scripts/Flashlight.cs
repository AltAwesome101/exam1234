using UnityEngine;
using TMPro;

public class Flashlight : MonoBehaviour, IInteractable
{
    public TextMeshProUGUI interactionPrompt;
public void PlayerInteraction()
    {
        Debug.Log("Interacting with the Flasglight!");
        // Add your generator interaction logic here
    }
}
