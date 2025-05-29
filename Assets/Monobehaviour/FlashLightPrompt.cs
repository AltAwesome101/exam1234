using UnityEngine;
using TMPro;
public class FlashlightPromptTrigger : MonoBehaviour
{
    public TextMeshProUGUI flashlightPrompt;

    public string message = "Press F to toggle flashlight";
    private void Start()
    {
        if (flashlightPrompt != null)
        {
            flashlightPrompt.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && flashlightPrompt != null)
        {
            flashlightPrompt.text = message;
            flashlightPrompt.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && flashlightPrompt != null)
        {
            flashlightPrompt.text = "";
            flashlightPrompt.gameObject.SetActive(false);
        }
    }
}