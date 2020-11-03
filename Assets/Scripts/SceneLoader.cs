using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    

    static public int GetSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    static public IEnumerator Reloading()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   static public IEnumerator Loading()
    {

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}
