using UnityEngine;
using System.Collections;

public class ShotMover : MonoBehaviour {
    Rigidbody rb;
    bool startDestroy;
    int destroyTimer;
    int lifeTimer;
	// Use this for initialization
	void Start () {
        startDestroy = false;
        destroyTimer = 120;
        lifeTimer = 250;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 40;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(--lifeTimer < 0 || destroyTimer < 0)
        {
            Destroy(gameObject);
        }
        if (startDestroy)
            --destroyTimer;
	}

    void OnCollisionEnter(Collision collision)
    {
        startDestroy = true;
    }
}
