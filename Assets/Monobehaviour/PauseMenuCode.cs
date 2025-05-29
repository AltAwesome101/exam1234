using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuCode : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;

    private bool isPaused = false;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        if (PauseMenu != null)
        {
            PauseMenu.SetActive(false); 
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LevelChange()
    {
        SceneChange.instance.LoadScene("Level 0 - Tutorial");
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }    
    public void Settings() 
    {
        // Will be Completed For Exam Sumbmission
    }
    public void Quit() 
    {
        Application.Quit();
    }

}
