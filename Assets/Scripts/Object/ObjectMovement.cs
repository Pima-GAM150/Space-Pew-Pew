using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {

    public Transform centerPoint;
    public Transform childObject;
    public float speed = 0.5f;

    private float radius;
    private float targetX;
    private float targetY;

	// Use this for initialization
	void Start () {
        //radius = Vector3.Distance(transform.position, centerPoint.position);
        //Debug.Log(clampDistance);
        targetX = childObject.localPosition.x;
        targetY = childObject.localPosition.y;
	}
	
	// Update is called once per frame
	void Update () {

    }

    //Make sure the parent object is facing the correct direction.
    public void MoveObject(float x, float y, float angle)
    {
        targetX = Mathf.Lerp(targetX, x, Time.time * speed);
        targetY = Mathf.Lerp(targetY, y, Time.time * speed);
        //Debug.Log("Moving object!");
        if(x != 0 && y != 0)
        {
            centerPoint.forward = new Vector3(targetX, targetY, 0f).normalized;
        }
        
        //transform.RotateAround(centerPoint.position, Vector3.forward, Vector2.Angle(centerPoint.forward, new Vector3(x, y, 0f).normalized) * Time.deltaTime);

        //Vector3 direction = new Vector3(x, y, 0f).normalized - centerPoint.position;
        //Quaternion toRotation = Quaternion.FromToRotation(centerPoint.forward, direction);
        //centerPoint.rotation = Quaternion.Lerp(centerPoint.rotation, toRotation, speed * Time.time);
    }

    public void MoveObjectRight(float x, float y, float angle)
    {
        //Debug.Log("Moving object!");
        if (x != 0 && y != 0)
        {
            centerPoint.right = new Vector3(x, y, 0f).normalized;
        }

        //transform.RotateAround(centerPoint.position, Vector3.forward, Vector2.Angle(centerPoint.forward, new Vector3(x, y, 0f).normalized) * Time.deltaTime);

        //Vector3 direction = new Vector3(x, y, 0f).normalized - centerPoint.position;
        //Quaternion toRotation = Quaternion.FromToRotation(centerPoint.forward, direction);
        //centerPoint.rotation = Quaternion.Lerp(centerPoint.rotation, toRotation, speed * Time.time);
    }

}
