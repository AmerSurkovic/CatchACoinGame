using UnityEngine;
using System.Collections;

public class CoinSpawner : MonoBehaviour {

    public GameObject coin;
    public static bool found;

    void Start()
    {
        found = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (found == true)
        {
            Vector3 rndPosWithin;
            rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);
            coin.transform.position = rndPosWithin;// Instantiate(coin, rndPosWithin, transform.rotation);
            found = false;
        }
    }
}
