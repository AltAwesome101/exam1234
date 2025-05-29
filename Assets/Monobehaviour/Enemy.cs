using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;
public class Enemy : Character1 
{
    public int damageStrength;

    Coroutine damageCoroutine;

    float hitPoints;

    [SerializeField] AudioSource effect;

    public AudioClip damage;
    public override void ResetCharacter()
    {
        hitPoints = startingHitPoints;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            effect.clip = damage;
            effect.Play();

            Player player = collision.gameObject.GetComponent<Player>();
            if (damageCoroutine == null) 
            {
                damageCoroutine = StartCoroutine(player.DamageCharacter(damageStrength, 1.0f));
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            if (damageCoroutine != null) 
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }
    public override IEnumerator DamageCharacter(int damage, float inteval)
    {
        while (true) 
        {
            hitPoints = hitPoints - damage;

            if (hitPoints <= 0) 
            {
                KillCharacter();
                break;
            }
            if (inteval > float.Epsilon) 
            {
                yield return new WaitForSeconds(inteval);
            }
            else 
            {
                break;
            }
        }
    }

}

