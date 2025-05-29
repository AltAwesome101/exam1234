using UnityEngine;
public class SpawnPoint : MonoBehaviour
{
    public GameObject prefabToSpawn;

    public float repeatInterval;
    void Start()
    {
        if (repeatInterval > 0)
        {
            InvokeRepeating("SpawnObject", 0.0f, repeatInterval);
        }
    }

    public GameObject SpawnObject()
    {
        return SpawnObject(null);
    }

    public GameObject SpawnObject(GameObject existingObject)
    {
        GameObject spawned = null;

        if (existingObject != null)
        {
            existingObject.transform.position = transform.position;
            spawned = existingObject;
        }
        else if (prefabToSpawn != null)
        {
            spawned = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }

        if (spawned != null)
        {
            Camera_Lock cam = Camera.main?.GetComponent<Camera_Lock>();
            if (cam != null)
            {
                cam.target = spawned.transform;
            }

            // Include a Mini Map for the Exam Game !!!!!!!!!!!!!!

            GameObject miniMapCamObj = GameObject.Find("Mini_Map_Camera");
            if (miniMapCamObj != null)
            {
                Camera_Lock miniMapCam = miniMapCamObj.GetComponent<Camera_Lock>();
                if (miniMapCam != null)
                {
                    miniMapCam.target = spawned.transform;
                }
            }
        }
        return spawned;
    }

}
