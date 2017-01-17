using UnityEngine;
using System.Collections;

public class RandomLocation : MonoBehaviour {

    public GameObject room;

    float x;
    float y;
    float z;
    float boxx;
    float boxy;
    float boxz;
    Vector3 pos;

    void Start()
    {
          x = Random.Range(1, room.GetComponent<Collider>().transform.lossyScale.x+2);
          y = Random.Range(2, room.GetComponent<Collider>().transform.lossyScale.y);
          z = Random.Range(1, room.GetComponent<Collider>().transform.lossyScale.z+2);

        float boxx = transform.lossyScale.x;
        float boxy = transform.lossyScale.y;
        float boxz = transform.lossyScale.z;

       /* x = Random.Range(0, boxx);
        y = Random.Range(1, boxy);
        z = Random.Range(0, boxz); */

       pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
