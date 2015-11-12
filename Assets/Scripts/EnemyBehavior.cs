using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent("PlayerController"))
        {
            Debug.Log(other.gameObject.GetComponent("PlayerController"));

            PlayerController player = (PlayerController)other.gameObject.GetComponent("PlayerController");
            if (player.numBulletsCollected() >= player.numBulletsNeeded())
            {
                player.collectBullet();
                Debug.Log(player.numBulletsCollected());
                GameObject tempText = GameObject.FindGameObjectWithTag("GameOverText");
                WinOrDie temp = (WinOrDie)tempText.GetComponent("WinOrDie");
                temp.win = true;
            }
            else
            {
                player.die();
        
            }

        }
    }
}
