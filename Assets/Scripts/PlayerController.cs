using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody rb;
    float velocity;
    float roll_velocity;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        velocity = 7.0f;
        roll_velocity = 5.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.velocity = Vector3.zero;
	    if(Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * velocity;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = transform.forward * -velocity;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = transform.right * -velocity;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * velocity;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = transform.up * -velocity;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = transform.up * velocity;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rb.rotation = rb.rotation * Quaternion.Euler(0.0f, 0.0f, -roll_velocity);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            rb.rotation = rb.rotation * Quaternion.Euler(0.0f, 0.0f, roll_velocity);
        }

        rb.rotation = rb.rotation * Quaternion.Euler(0.0f, Input.GetAxis("Mouse X"), 0.0f);
        rb.rotation = rb.rotation * Quaternion.Euler(Input.GetAxis("Mouse Y"),  0.0f, 0.0f);
    }
}
