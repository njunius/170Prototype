using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BombTextController : MonoBehaviour {

    Text bombArmingText;
    public PlayerController player;
    float bombToPercentage;
	// Use this for initialization
	void Start () {
        bombArmingText = GetComponent<Text>();
        bombToPercentage = 0;
	}
	
	// Update is called once per frame
	void Update () {
        bombToPercentage = (player.numBulletsCollected() / player.numBulletsNeeded()) * 100f;
        if(bombToPercentage == 100)
            bombArmingText.text = "Bomb Energy: " + bombToPercentage.ToString("000.00") + "%";
        else if(bombToPercentage < 10)
            bombArmingText.text = "Bomb Energy: " + bombToPercentage.ToString("0.00") + "%";
        else
            bombArmingText.text = "Bomb Energy: " + bombToPercentage.ToString("00.00") + "%";
    }
}
