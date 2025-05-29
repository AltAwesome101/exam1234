using UnityEngine;
using System.Collections;
public abstract class Character1 : MonoBehaviour
{
    public float maxHitPoints;
    
    public float startingHitPoints;
    public virtual void KillCharacter()
    {
        Destroy(gameObject);
    }
    public abstract void ResetCharacter();
    public abstract IEnumerator DamageCharacter(int damage, float inteval);
    private void OnEnable()
    {
        ResetCharacter();
    }
}    

