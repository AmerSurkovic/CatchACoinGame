using UnityEngine;
using System.Collections;

public class PlayerRaycasting : MonoBehaviour
{

    public float distanceToSee;
    RaycastHit whatIHit;

    // Use this for initialization
    void Start()
    {

    }

    bool label = false;

    // Update is called once per frame
    void Update()
    {
        label = false;
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
        {
            label = true;
            Debug.Log("I touched " + whatIHit.collider.gameObject.name);

            if (whatIHit.collider.gameObject.name == "Coin" && Input.GetKeyDown("e"))
            {
                //Destroy(whatIHit.collider.gameObject);

                CoinSpawner.found = true;
                ScoreManager.score += 20;
            }
            if (whatIHit.collider.gameObject.name == "LightSwitch" && Input.GetKeyDown("e"))
            {
                if(LightToggle.toggle==true)
                    LightToggle.toggle = false;
                else
                    LightToggle.toggle = true;
            }
            if (whatIHit.collider.gameObject.name == "smartphone" && Input.GetKeyDown("e"))
            {
                Destroy(whatIHit.collider.gameObject);

                int nmb = Random.Range(1,100);

                if (nmb % 2 == 0)
                    ScoreManager.score -= 50;
                else
                    ScoreManager.score += 50;
            }
            if (whatIHit.collider.gameObject.name == "RestCouch" && Input.GetKeyDown("e"))
            {
                    ScoreManager.score -= 30;
                    Timer.timeLeft += 10;
            }
        }
    }

    void OnGUI()
    {
        if (label && whatIHit.collider.gameObject.name == "Coin")
        {
            GUI.Box(new Rect(Screen.width - 100, Screen.height - 50, 90, 40), "Pokupi me!");//whatIHit.collider.gameObject.name);
        }
        if (label && whatIHit.collider.gameObject.name == "LightSwitch")
        {
            GUI.Box(new Rect(Screen.width - 100, Screen.height - 50, 90, 40), "Svjetlo!");//whatIHit.collider.gameObject.name);
        }
        if (label && whatIHit.collider.gameObject.name == "smartphone")
        {
            GUI.Box(new Rect(Screen.width - 100, Screen.height - 50, 90, 40), "Javi se!");//whatIHit.collider.gameObject.name);
        }
        if (label && whatIHit.collider.gameObject.name == "RestCouch")
        {
            GUI.Box(new Rect(Screen.width - 100, Screen.height - 50, 90, 40), "Odmori!");//whatIHit.collider.gameObject.name);
        }
    }
}
