using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AdjustScript : MonoBehaviour {
        
        public Text status;

        public GameObject panel;

        public void Save(){ 
            GameControl_Players.control.Save();

            status.text = "Spaseno!";
        }
        public void Load() { 
            GameControl_Players.control.Load();
        }

        public void LoadPosition()
        {
            GameControl_Players.control.LoadPosition();
            panel.gameObject.SetActive(false);
            PauseMenuScript.paused = false;
        }

    /* void OnGUI() { 
         string x = GameControl_Players.control.Write();
         GUI.Box(new Rect(0, Screen.height - 50, 100, 50), x); 
     }*/
}
