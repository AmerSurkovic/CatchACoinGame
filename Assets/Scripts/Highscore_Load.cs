using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Highscore_Load : MonoBehaviour {

    public GameObject highScorepanel;

    /*  void OnGUI()
      {
          int box = 10;
          List<PlayerRecord> x = GameControl_Players.control.HighScore();

          foreach(PlayerRecord y in x) { 
              GUI.Box(new Rect(Screen.width / 2 - 50, Screen.height / 2 + box, 100, 50), y.name + " " + y.points.ToString());
              box += 40;
          }
      }*/

    Text score;

    void Start()
    {
        List<PlayerRecord> x = GameControl_Players.control.HighScore();

        x.Sort((t, y) => y.points.CompareTo(t.points));

        score = GetComponent<Text>();
        score.text = "";
        int nmb = 1;

        score.text += "Mjesto - " + "Ime - " + "Poeni" + System.Environment.NewLine;
        foreach (PlayerRecord y in x)
        {
            score.text += nmb + ". " + y.name + " " + y.points.ToString() + System.Environment.NewLine;
            nmb++;
        }

    } 
    
}
