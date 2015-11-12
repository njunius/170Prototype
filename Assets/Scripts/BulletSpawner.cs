using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {

    public Transform target;
    public GameObject shot;
    int ROF;
	// Use this for initialization
	void Start () {
        ROF = 10;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(ROF == 10)
        {
            GameObject clone = (GameObject) Instantiate(shot, transform.position, transform.rotation);
            EnemyShotMover temp = (EnemyShotMover) clone.GetComponent("EnemyShotMover");
            temp.target = target;
            ROF = -1;
        }
        ++ROF;

    }
}
