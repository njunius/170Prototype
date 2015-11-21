using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {

    public GameObject shot;
    int ROF;
    int deltaAngle;
    int reverseDeltaAngle;
	// Use this for initialization
	void Start () {
        ROF = 5;
        deltaAngle = 0;
        reverseDeltaAngle = 0;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation =Random.rotation;
        if(ROF == 5)
        {
            Vector3 patternSpread = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            patternSpread.y += deltaAngle;
            patternSpread.x -= deltaAngle;
            patternSpread *= -1;
            Instantiate(shot, transform.position, Quaternion.Euler(patternSpread));
            ROF = -1;
            deltaAngle += 5;
        }
        if(ROF == 0)
        {
            Vector3 patternSpread = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            patternSpread.y += reverseDeltaAngle;
            patternSpread.x -= reverseDeltaAngle;
            patternSpread *= -1;
            Instantiate(shot, transform.position, Quaternion.Euler(patternSpread));
            reverseDeltaAngle -= 5;
        }
        
        ++ROF;

    }
            
}
