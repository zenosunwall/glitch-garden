using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int secondsToWait = 3;

    int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadStartScreenWithDelay());
        }
    }

    private IEnumerator LoadStartScreenWithDelay()
    {
        yield return new WaitForSeconds(secondsToWait);
        LoadNextScence();
    }

    public void LoadNextScence()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void RestartSceen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }
}
