using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {

    public GameObject shot;
    public Transform target;
    int ROF;
	// Use this for initialization
	void Start () {
        ROF = 40;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(target, transform.up);
        transform.Rotate(transform.forward, 5);
        if(ROF == 40)
        {
            for (int i = -20; i < 20; i += 5)
            {
                GameObject clone = (GameObject) Instantiate(shot, transform.position, transform.rotation);
                // spread bullets out along a plane that rotates every shot
                clone.transform.Rotate(transform.forward, i);

            }
            ROF = -1;
        }        
        ++ROF;

    }
            
}
