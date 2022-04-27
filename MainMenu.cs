using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private AsyncOperation asyncLoad;
    public void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        asyncLoad = SceneManager.LoadSceneAsync("LoadingScreen");
        asyncLoad.allowSceneActivation = false;
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
    }

    public void StartGame()
    {
        asyncLoad.allowSceneActivation = true;
       // SceneManager.LoadScene("LoadingScreen");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
