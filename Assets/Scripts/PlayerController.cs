using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    bool shielded;
    bool locked;
    bool switched;
    public GameObject target;
    public GameObject shot;
    public Transform shotSpawn;
    public RectTransform shieldBarTransform;
    Rigidbody rb;
    float cachedShieldY;
    float cachedShieldX;
    float shieldToBarMap;
    float velocity;
    float roll_velocity;
    int ROF;
    int shieldChargeControl;
    int shieldChargeMax;
    int shieldRechargeDelay;
    int shieldRechargeDelayReset;

	// Use this for initialization
	void Start () {
        // shield control
        shieldChargeControl = 0;
        shieldRechargeDelay = shieldRechargeDelayReset = 4;
        cachedShieldY = shieldBarTransform.position.y;
        cachedShieldX = shieldBarTransform.position.x;
        shieldChargeMax = 180;
        shieldToBarMap = -shieldBarTransform.rect.width / shieldChargeMax;
        // fire control
        ROF = 5;
        // camera control
        locked = false;
        switched = false;
        // movement control
        rb = GetComponent<Rigidbody>();
        velocity = 20.0f;
        roll_velocity = 5.0f;
	}
	
	// Update is called once per frame
    void Update()
    {
        Debug.Log(cachedShieldX + shieldChargeControl * shieldToBarMap);
        shieldBarTransform.position = new Vector3(cachedShieldX + shieldChargeControl * shieldToBarMap, cachedShieldY, 0);

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

        if (Input.GetKeyDown(KeyCode.LeftControl) && !shielded && shieldChargeControl == 0)
        {
            shielded = true;
        }
    }
    
	void FixedUpdate () {
        ++ROF;
        if (shielded)
        {
            ++shieldChargeControl;
            if(shieldChargeControl > shieldChargeMax)
            {
                shieldChargeControl = shieldChargeMax;
                shielded = false;
            }
        }
        else if(!shielded && shieldChargeControl > 0)
        {
            if(shieldRechargeDelay % shieldRechargeDelayReset == 0)
            {
                --shieldChargeControl;
                shieldRechargeDelay = 0;
            }
            ++shieldRechargeDelay;
        }

        // movement based on camera type
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
