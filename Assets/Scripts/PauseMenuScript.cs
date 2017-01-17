using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenuScript : MonoBehaviour {

    public Canvas pauseCanvas;
    public static bool paused = false;
    public Camera fpc;
    public GameObject panel;

    // Use this for initialization
    void Start () {
        panel.gameObject.SetActive(false);
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
	    if(!paused && Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
        else if(paused && Input.GetKeyDown(KeyCode.R))
        {
            ResumeGame();
        }
	}

    void PauseGame()
    {
        paused = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        panel.gameObject.SetActive(true);

    }

    void ResumeGame()
    {
        paused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        panel.gameObject.SetActive(false);

    }
}
