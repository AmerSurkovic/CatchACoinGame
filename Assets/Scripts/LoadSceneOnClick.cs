using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByIndex(int sceneIndex) 
    {
        Time.timeScale = 1; 

        SceneManager.LoadScene(sceneIndex);
    }

    public void lastGame(int index)
    {
        if (index == 1)
            GameControl_Players.loadGame = true;
        else
            GameControl_Players.loadGame = false;

    }

}
