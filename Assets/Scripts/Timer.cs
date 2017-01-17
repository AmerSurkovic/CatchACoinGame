using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public static float timeLeft = 50.0f;

    public Text text;

    public GameObject endGamePanel;

    void Start()
    {
        if(GameControl_Players.loadGame != true)
            timeLeft = 50.0f;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        text.text = "Vrijeme: " + Mathf.Round(timeLeft);

        if(timeLeft < 0)
        {
            Time.timeScale = 0;
            endGamePanel.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            endGamePanel.gameObject.SetActive(false);
        }

    }
}
