using UnityEngine;

public class LevelJumpOpp : MonoBehaviour
{
    [Tooltip("Name Of Scene")]

    public string targetSceneName;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) 
        {
            if (!string.IsNullOrEmpty(targetSceneName))
            {
                SceneChange.instance.LoadScene(targetSceneName);
            }
            else
            {
                Debug.LogWarning("LevelJump: You Never Set The Scene Bro!");
            }
        }
    }
}
