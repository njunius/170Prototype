using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    // camera fields
    bool locked;
    bool switched;
    public GameObject target;
    // movement fields
    Rigidbody rb;
    float velocity;
    float roll_velocity;
    // firing fields
    public GameObject shot;
    public Transform shotSpawn;
    int ROF;
    // shield fields
    int shieldChargeControl;
    int shieldChargeMax;
    int shieldRechargeDelay;
    int shieldRechargeDelayReset;
    float cachedShieldY;
    float cachedShieldX;
    float shieldToBarMap;
    public bool shielded;
    public RectTransform shieldBarTransform;
    // bomb fields
    int bulletsCollected;
    public int bulletsNeeded;

    bool isDead;

    // Use this for initialization
    void Start () {
        isDead = false;
        // bullet collection
        bulletsCollected = 0;
        bulletsNeeded = 20;
        // shield control
        shieldChargeControl = 0;
        shieldRechargeDelay = shieldRechargeDelayReset = 6;
        cachedShieldY = shieldBarTransform.position.y;
        cachedShieldX = shieldBarTransform.position.x;
        shieldChargeMax = 120;
        shieldToBarMap = -shieldBarTransform.rect.width / shieldChargeMax;
        // fire control
        ROF = 5;
        // camera control
        locked = true;
        switched = false;
        // movement control
        rb = GetComponent<Rigidbody>();
        velocity = 20.0f;
        roll_velocity = 5.0f;
	}

    public bool isShielded()
    {
        return shielded;
    }

    public float numBulletsCollected()
    {
        return bulletsCollected;
    }
    public float numBulletsNeeded()
    {
        return bulletsNeeded;
    }
    public void collectBullet()
    {
        ++bulletsCollected;
    }

    public void die()
    {
        isDead = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
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
                // make direction and velocity vectors local for easy addition of components
                Vector3 localForward = transform.InverseTransformDirection(transform.forward);
                Vector3 localVelocity = new Vector3(0, 0, transform.InverseTransformDirection(rb.velocity).z);
                GameObject newShot = (GameObject)Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                //Debug.Log(transform.InverseTransformDirection(rb.velocity));
                //Debug.Log(transform.InverseTransformDirection(transform.forward));
                // add constant forward velocity to newShot and add the player's forward velocity component
                newShot.GetComponent<Rigidbody>().velocity = transform.TransformDirection(localForward * 40 + localVelocity);
                ROF = 0;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1) && !shielded && shieldChargeControl == 0)
            {
                shielded = true;
            }
        }
        
    }
    
	void FixedUpdate () {
        if (!isDead)
        {
            ++ROF;
            if (shielded)
            {
                ++shieldChargeControl;
                if (shieldChargeControl > shieldChargeMax)
                {
                    shieldChargeControl = shieldChargeMax;
                    shielded = false;
                }
            }
            else if (!shielded && shieldChargeControl > 0)
            {
                if (shieldRechargeDelay % shieldRechargeDelayReset == 0)
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
                rb.velocity = transform.forward * velocity / 2;
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
}
