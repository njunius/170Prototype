using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    bool locked;
    bool switched;
    public GameObject target;
    public GameObject shot;
    public Transform shotSpawn;
    Rigidbody rb;
    float velocity;
    float roll_velocity;
    int ROF;

	// Use this for initialization
	void Start () {
        ROF = 5;
        locked = false;
        switched = false;
        rb = GetComponent<Rigidbody>();
        velocity = 20.0f;
        roll_velocity = 5.0f;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            locked = !locked;
            switched = !switched;
            if (locked && switched)
            {
                transform.LookAt(target.transform, transform.up);
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && ROF > 4)
        {
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            ROF = 0;
        }
    }
    
	void FixedUpdate () {
        ++ROF;
        if (!locked)
        {
            rb.velocity = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity += transform.forward * velocity;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity -= transform.forward * velocity;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity -= transform.right * velocity;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity += transform.right * velocity;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity -= transform.up * velocity;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity += transform.up * velocity;
            }
            if (Input.GetKey(KeyCode.E))
            {
                rb.MoveRotation(rb.rotation * Quaternion.Euler(0.0f, 0.0f, -roll_velocity));
            }
            if (Input.GetKey(KeyCode.Q))
            {
                rb.MoveRotation(rb.rotation * Quaternion.Euler(0.0f, 0.0f, roll_velocity));
            }

            rb.MoveRotation(rb.rotation * Quaternion.Euler(0.0f, Input.GetAxis("Mouse X"), 0.0f));
            rb.MoveRotation(rb.rotation * Quaternion.Euler(Input.GetAxis("Mouse Y"), 0.0f, 0.0f));
        }
        else
        {
            // camera control forces the ship to fly towards its target
            rb.velocity = transform.forward * velocity/2;
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity += transform.forward * velocity;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity -= transform.forward * velocity;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity -= transform.right * velocity;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity += transform.right * velocity;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity -= transform.up * velocity;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                rb.velocity += transform.up * velocity;
            }
            if (Input.GetKey(KeyCode.E))
            {
                transform.rotation *= Quaternion.Euler(0.0f, 0.0f, -roll_velocity);
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.rotation *= Quaternion.Euler(0.0f, 0.0f, roll_velocity);
            }
            transform.LookAt(target.transform, transform.up);
        }

    }
}
