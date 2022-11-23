using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void SceneChanging(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
        
    }
}
