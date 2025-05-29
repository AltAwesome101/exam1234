using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGGameManager : MonoBehaviour
{
    public static RPGGameManager sharedInstance = null;

    public SpawnPoint playerSpawnPoint;

    private GameObject currentPlayer;
   
    public int generatorStage = 0;

    void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void SetupScene()
    {
        playerSpawnPoint = FindObjectOfType<SpawnPoint>();

        
        if (playerSpawnPoint == null)
        {
            return;
        }

        if (currentPlayer == null)
        {
            currentPlayer = playerSpawnPoint.SpawnObject();
            DontDestroyOnLoad(currentPlayer);
        }
        else
        {
            playerSpawnPoint.SpawnObject(currentPlayer);
        }
    }
    public void SpawnPlayer()
    {
        if (currentPlayer == null && playerSpawnPoint != null)
        {
            currentPlayer = playerSpawnPoint.SpawnObject();
            DontDestroyOnLoad(currentPlayer);

            SetCameraFollow(currentPlayer.transform);
        }
    }

    private void SetCameraFollow(Transform target)
    {
        Camera mainCam = Camera.main;
        if (mainCam == null) return;

        Camera_Lock cameraLock = mainCam.GetComponent<Camera_Lock>();
        if (cameraLock != null)
        {
            cameraLock.target = target;
        }
    }
    public bool IsGeneratorFullyRepaired()
    {
        return generatorStage >= 3;
    }
}