using UnityEngine;

public class TriggerParticleEffect2D : MonoBehaviour
{
    [Header("Particle Effect")]

    public ParticleSystem particleEffect;

    void Start()
    {
        if (particleEffect == null)
        {
            particleEffect = GetComponent<ParticleSystem>();
        }

        if (particleEffect != null)
        {
            particleEffect.Stop();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && particleEffect != null && !particleEffect.isPlaying)
        {
            particleEffect.Play();
        }
    }
}
