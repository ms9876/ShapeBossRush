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
    public void Exiting()
    {
        Application.Quit();
    }
    public void ActiveTrueObject(GameObject active)
    {
        active.SetActive(true);
    }
}
