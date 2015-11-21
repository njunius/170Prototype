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
        //transform.LookAt(target);
        rb.velocity = transform.forward * 20;
    }

    void FixedUpdate()
    {
        if (lifetime < 1)
            Destroy(gameObject);
        --lifetime;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerController player = (PlayerController)GameObject.FindGameObjectWithTag("Player").GetComponent("PlayerController");
        if (other.gameObject.GetComponent("PlayerController") || other.gameObject.tag == "Shield")
        {
            Debug.Log(other.gameObject.GetComponent("PlayerController"));

            if (player.isShielded())
            {
                player.collectBullet();
                Debug.Log(player.numBulletsCollected());
            }

        }
        if (other.gameObject.GetComponent("PlayerController") && !player.isShielded())
        {
            player.die();
            GameObject tempText = GameObject.FindGameObjectWithTag("GameOverText");
            WinOrDie temp = (WinOrDie)tempText.GetComponent("WinOrDie");
            temp.dead = true;
        }
        if(other.gameObject.tag != "Bullet")
            Destroy(gameObject);
    }
}
