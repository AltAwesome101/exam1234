using UnityEngine;
public class LevelJump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player")) 
        {
            SceneChange.instance.NextLevel();
        }
    }
}
