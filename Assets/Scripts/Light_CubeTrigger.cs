using UnityEngine;
using System.Collections;

public class Light_CubeTrigger : MonoBehaviour {

    public GameObject tvScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider x)
    {
     //   LightToggle.toggle = false;
        tvScreen.active = true;
    }

    void OnTriggerExit(Collider x)
    {
      //  LightToggle.toggle = true;
        tvScreen.active = false;
    }
}
