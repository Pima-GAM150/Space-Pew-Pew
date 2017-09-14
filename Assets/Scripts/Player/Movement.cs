using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : MonoBehaviour {

    //https://www.youtube.com/watch?v=uv2QSvuwIDs&feature=youtu.be&t=35m19s - animation stuff
    //https://www.youtube.com/watch?v=wnoLaui3uO4 - dungeon generation

    public float speed = 0.1f;
    //public Camera mainCamera;
    public Joystick joystick;

    //private Quaternion locationRotation;

	// Use this for initialization
	void Start () {
        //locationRotation = mainCamera.transform.rotation;
        //Input.gyro.enabled = true;
        joystick = GetComponent<Joystick>();
	}
	
	// Update is called once per frame
	void Update () {

        //move the character around based on tilting the phone left and right.
        //MOVES REALLY FAST
        //transform.Translate(Input.acceleration.x * speed, Input.acceleration.y * speed, 0);

        //locationRotation.z += Input.acceleration.x;
        //mainCamera.transform.rotation = locationRotation;

        //Multiplying by 10 so that the character moves slower.
        this.transform.position += new Vector3((joystick.transform.position.x-joystick.startPosition.x) / (joystick.movementRange * 10), (joystick.transform.position.y-joystick.startPosition.y) / (joystick.movementRange * 10));

        //Checking the different positions
        //Vector3 joystickPosition = new Vector3((joystick.transform.position.x - joystick.startPosition.x) / (joystick.movementRange * 10), (joystick.transform.position.y - joystick.startPosition.y) / (joystick.movementRange * 10));
        //this.transform.position += joystickPosition;
        //Debug.Log(joystickPosition + ", " + this.transform.position);

        //transform.rotation = locationRotation;
        //transform.Rotate(0f, 0f, 1f);

    }


}
