using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LookAt : MonoBehaviour {

    public Rigidbody rb;
    public Transform turret;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void lookWhereMoving()
    {
        //use the velocity as the direction you want to look at so that the vehicle will face the direction the force is being applied towards
        Vector3 direction = rb.velocity;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 2f * Time.deltaTime);
    }

    public void lookWhereMoving(Vector3 target)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, target - transform.position);
        //Vector3 direction = new Vector3(this.transform.position.x, this.transform.position.y, target.z);
        //transform.LookAt(direction);
    }
}
