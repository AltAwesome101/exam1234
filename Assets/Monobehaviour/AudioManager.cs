using UnityEngine;
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource music;

    public AudioClip background;
    void Start()
    {
        music.clip = background;
        music.Play();
    }
}
