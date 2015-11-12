using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinOrDie : MonoBehaviour {

    Text gameOver;
    public bool win;
    public bool dead;
	// Use this for initialization
	void Start () {
        gameOver = GetComponent<Text>();
        gameOver.text = "";
        win = false;
        dead = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (win)
        {
            gameOver.text = "You Win";
            gameOver.color = new Color(0, 1, 0);
        }
        else if (dead)
        {
            gameOver.text = "You Died";
            gameOver.color = new Color(1, 0, 0);
        }

        if(win || dead){
            if (Input.GetKey(KeyCode.L))
                Application.LoadLevel("PrototypeRoom1");
            if (Input.GetKey(KeyCode.Escape))
                Application.Quit();
        }
    }
}
