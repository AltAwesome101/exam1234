using UnityEngine;
using UnityEngine.U2D;

// Dont Use This Script
public class RPGCameraManager : MonoBehaviour
{
    public static RPGCameraManager sharedInstance = null;
    
    void Awake() 
    {
        if (sharedInstance != null && sharedInstance != this) 
        {
            Destroy(gameObject);
        }
        else 
        {
            sharedInstance = this;
        }

        //GameObject vCamGameObject = GameObject.FindWithTag("VirtualCamera");

        //virtualCamera = vCamGameObject.GetComponent<CinemachineCamera>();
    }
   
}
