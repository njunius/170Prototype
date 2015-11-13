﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject positionTarget;
    public GameObject lookAtTarget;
    Vector3 cameraOffset;
	// Use this for initialization
	void Start () {
        //Cursor.visible = false;
        cameraOffset = new Vector3(0.0f, -0.7f, 3.0f);
        transform.position = positionTarget.transform.position - cameraOffset;

        transform.LookAt(lookAtTarget.transform);
	}
	
	// Update is called once per frame
	void LateUpdate () {

    }
}
