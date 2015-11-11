using UnityEngine;
using System.Collections;

public class ShotMover : MonoBehaviour {
    Rigidbody rb;
    public GameObject shooter;
    public AudioSource destroySound;
    public AudioSource fireSound;
    bool startDestroy;
    int destroyTimer;
    int lifeTimer;
	// Use this for initialization
	void Start () {
        fireSound.Play();
        startDestroy = false;
        destroyTimer = 120;
        lifeTimer = 250;
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 40 + transform.forward * Mathf.Abs(shooter.GetComponent<Rigidbody>().velocity.z);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(--lifeTimer < 0 || destroyTimer < 0)
        {
            destroySound.Play();

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
