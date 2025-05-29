using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public TextMeshProUGUI interactionPrompt;
    private IInteractable currentInteractable;

    void Update()
    {
        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.PlayerInteraction();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            Debug.Log("Entered trigger with: " + other.name);
            currentInteractable = interactable;

            if (interactionPrompt != null)
            {
                interactionPrompt.text = "Press E to interact";
                interactionPrompt.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null && interactable == currentInteractable)
        {
            Debug.Log("Exited trigger with: " + other.name);
            currentInteractable = null;

            if (interactionPrompt != null)
            {
                interactionPrompt.text = "";
                interactionPrompt.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Exited something that isn't the current interactable: " + other.name);
        }
    }
}

