using UnityEngine;
using System.Collections;

public class ShieldOnOff : MonoBehaviour {

    PlayerController player;
    // Use this for initialization
    void Start()
    {
        player = (PlayerController) transform.parent.gameObject.GetComponent("PlayerController");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isShielded())
            GetComponent<MeshRenderer>().enabled = true;
        else
            GetComponent<MeshRenderer>().enabled = false;
    }
}

