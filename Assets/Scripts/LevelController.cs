using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] float winDelay;

    int numberOfEnemies = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AddEnemy()
    {
        numberOfEnemies++;
    }

    public void RemoveEnemy()
    {
        numberOfEnemies--;
        if (numberOfEnemies == 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
            
        }
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    private IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(winDelay);
        FindObjectOfType<LevelLoader>().LoadNextScence();
    }

    public void SetGameEnd()
    {
        DisableSpawners();
        levelTimerFinished = true;
    }

    void DisableSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
