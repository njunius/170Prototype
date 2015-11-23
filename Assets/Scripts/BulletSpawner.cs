using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {

    public GameObject shot;
    public Transform target;
    int ROF;
    int deltaAngle;
	// Use this for initialization
	void Start () {
        ROF = 40;
        deltaAngle = 0;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(target, transform.up);
        transform.Rotate(transform.forward, 5);
        if(ROF == 40)
        {
            for (int i = -20; i < 20; i += 10)
            {
                Instantiate(shot, transform.position, Quaternion.AngleAxis(i, transform.up));
            }
            ROF = -1;
        }        
        ++ROF;

    }
            
}
