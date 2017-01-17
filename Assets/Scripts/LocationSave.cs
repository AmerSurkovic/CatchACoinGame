using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LocationSave : MonoBehaviour {

    public Text status;

    public void SavePosition()
    {
        GameControl_Players.control.SavePosition();

        status.text = "Spaseno!";

    }
}
