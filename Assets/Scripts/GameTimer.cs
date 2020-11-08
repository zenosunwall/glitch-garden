using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level Timer In Seconds")]
    [SerializeField] float levelTime = 10f;

    bool timerFinished = false;

    // Update is called once per frame
    void Update()
    {
        if (timerFinished) { return; }
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            FindObjectOfType<LevelController>().SetGameEnd();
        }
    }

}

