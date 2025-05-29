using UnityEngine;
using UnityEngine.UI;
public class IntroScreenManager : MonoBehaviour
{
    public GameObject introUI;

    private bool introActive = true;
    void Start()
    {
        if (introUI != null)
        {
            introUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    void Update()
    {
        if (introActive && Input.GetKeyDown(KeyCode.Return))
        {
            if (introUI != null)
            {
                introUI.SetActive(false);
                Time.timeScale = 1f;
                introActive = false;
            }
        }
    }
}
