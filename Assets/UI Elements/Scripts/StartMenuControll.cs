using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuControll : MonoBehaviour
{
    [SerializeField] private GameObject[] canvasLoader; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void loadNext(int index)
    {
        canvasLoader[index].SetActive(false);
        
        canvasLoader[index + 1].SetActive(true);
    }

    public void loadOptions()
    {
        canvasLoader[0].SetActive(false);
        canvasLoader[4].SetActive(true);

    }

    public void loadStart()
    {
        canvasLoader[4].SetActive(false);
        canvasLoader[0].SetActive(true);

    }

    
        public void LoadSceneByName(string sceneName)
        {
           
                SceneChange.instance.LoadScene(sceneName);
            
            
        }
    }


