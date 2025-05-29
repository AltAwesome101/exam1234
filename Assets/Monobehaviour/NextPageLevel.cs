using UnityEngine;
using UnityEngine.SceneManagement;
public class NextPageButton : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level 0 - Tutorial");
    }
}