using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    //reference to gameobject and UI elements for loading screen
    public GameObject loadingscreen;
    public Image progressBar;
    public Text progressBarText;

    /// <summary>
    /// method to call the coroutine when scene is ready to be changed
    /// </summary>
    /// <param name="sceneIndex"></param>
    public void LoadLevel(int sceneIndex)
    {

        StartCoroutine(LoadAsynchronously(sceneIndex));

    }

    /// <summary>
    /// Coroutine method to fill the progress bar float variable in sync with the scene changing
    /// </summary>
    /// <param name="sceneIndex"></param>

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        //declare the operation
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        //start while loop against operation
        while (!operation.isDone)
        {
            //fill progress bar over time
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            progressBar.fillAmount = progress;
            progressBarText.text = progress * 100 + "%";

            yield return null;
        }
    }
}
