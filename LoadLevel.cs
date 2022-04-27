using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel: MonoBehaviour {

    [SerializeField]
    private Image progressBar;

    public void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Main");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            progressBar.fillAmount = asyncLoad.progress;
            yield return null;
        }
    }
}
