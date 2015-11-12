using UnityEngine;
using System.Collections;

public class EnemyShotMover : MonoBehaviour
{

    public Transform target;
    Rigidbody rb;
    public int lifetime;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.LookAt(target);
        rb.velocity = transform.forward * 50;
    }

    void FixedUpdate()
    {
        if (lifetime < 1)
            Destroy(gameObject);
        --lifetime;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent("PlayerController"))
        {
            Debug.Log(other.gameObject.GetComponent("PlayerController"));

            PlayerController player = (PlayerController)other.gameObject.GetComponent("PlayerController");
            if (player.isShielded())
            {
                player.collectBullet();
                Debug.Log(player.numBulletsCollected());
            }
            else
            {
                player.die();
                GameObject tempText = GameObject.FindGameObjectWithTag("GameOverText");
                WinOrDie temp = (WinOrDie) tempText.GetComponent("WinOrDie");
                temp.dead = true;
            }

        }
        Destroy(gameObject);
    }
}
