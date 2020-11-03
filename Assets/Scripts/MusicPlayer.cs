using UnityEngine;


public class MusicPlayer : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Awake()
    {
        if (FindObjectsOfType<MusicPlayer>().Length > 1)
            Destroy(gameObject);

        else
            DontDestroyOnLoad(gameObject);
        if (SceneLoader.GetSceneIndex() == 0)
        {
            StartCoroutine(SceneLoader.Loading());
        }
        
    }

    
}
