using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {

	// Use this for initialization
	public void loadGame()
    {
        GameControl_Players.loadGame = true;
    }
}
