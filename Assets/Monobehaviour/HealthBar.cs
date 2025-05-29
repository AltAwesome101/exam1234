using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class HealthBar : MonoBehaviour
{
    public HitPoints hitPoints;
    
    public Player character;

    public Image meterImage;

    public TextMeshProUGUI hpText;

    float maxHitPoints;
    void Start()
    {
        maxHitPoints = character.maxHitPoints;
        StartCoroutine(FindPlayerHealth());
    }
    void Update()
    {
        if (character != null) 
        {
            meterImage.fillAmount = hitPoints.value / maxHitPoints;
            hpText.text = "HP:" + (meterImage.fillAmount * 100);
        }
    }
    IEnumerator FindPlayerHealth() 
    {
        while (GameObject.FindWithTag("Player") == null) 
        {
            yield return null;
        }
        hitPoints = GameObject.FindWithTag("Player").GetComponent<Player>().hitPoints;
    }
}
