using UnityEngine;
using System.Collections;

public class LightToggle : MonoBehaviour {

    public static bool toggle = true;
    public Light myLight;

    // Use this for initialization
    void Start () {
      //  myLight.enabled = !myLight.enabled;
    }
	
	// Update is called once per frame
	void Update () {
        if (toggle == false)
        {
            myLight.enabled = false;
        }
        else if (toggle == true)
        {
            myLight.enabled = true;
        }
	}
}
