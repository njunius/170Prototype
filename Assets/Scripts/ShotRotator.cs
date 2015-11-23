using UnityEngine;
using System.Collections;

public class ShotRotator : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 20;
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(transform.forward, 5);
	}
}
