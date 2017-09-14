using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilot : PlayerClass {

    /*
     *Abilities
     * Forward
     * Boost
     * Hover 
     */
    public List<string> abilities = new List<string>() { "Forward", "Boost", "Hover", "Action" };
    //private Collider stationCollider;
    private float squareTimer = 0f;
    private float squareTimerDuration = 0.2f; //When you hit the square button it sends over a bunch of trues so it is executing multiple times in a row.

    private Rigidbody rb;
    private float maxSpeed = 5f;
    private float maxMagnitude = 2f;
    
     public Pilot()
    {
        //className = ClassName.pilot;
    }

    // Use this for initialization
    void Start () {
        objControlling = GameObject.Find("EngineCenterPoint");
        centerPoint = GameObject.Find("Engine");
        ship = GameObject.Find("Ship");
        rb = ship.GetComponent<Rigidbody>();
        //className = ClassName.pilot;
	}
	
	// Update is called once per frame
	void Update () {
        squareTimer += Time.deltaTime;
	}

    public override void Circle()
    {
        if (sitting)
        {
            Debug.Log("Executing Circle");

            Vector3 desired = rb.velocity;
            desired.Normalize();
            ApplyForce(-desired * 4f);
            //Debug.Log(rb.velocity);

            if (rb.velocity.magnitude < 0.1f)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }

        }
        
    }

    public override void Square()
    {
        if(squareTimer > squareTimerDuration)
        {
            Debug.Log("Executing Square!");
            squareTimer = 0f;
            if (!sitting && atStation)
            {
                sitting = true;
                transform.parent = stationCollider.transform;
                transform.position = new Vector3(stationCollider.transform.position.x, stationCollider.transform.position.y, 10f);
                this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            }
            else if (sitting)
            {
                sitting = false;
                transform.parent = GameObject.Find("Ship").transform;
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            }
        }



    }

    public override void Triangle()
    {
        throw new NotImplementedException();
    }

    //Moves the ship
    public override void X()
    {
        if(sitting)
        {

            if (ship.GetComponent<ShipManager>().currentEngineEnergy > 0)
            {
                Debug.Log("Executing X");
                Vector3 desired = objControlling.transform.position - centerPoint.transform.position;
                //Debug.Log("Desired: " + desired);
                //normalize
                desired.Normalize();
                //Debug.Log("Normalized: " + desired);
                ApplyForce(desired * 6f);
                ship.GetComponent<ShipManager>().engineEnergyBar.changeEnergyBar(ship.GetComponent<ShipManager>().currentEngineEnergy -= 1, ship.GetComponent<ShipManager>().maxEngineEnergy);
            }

        }

    }

    public void ApplyForce(Vector3 force)
    {

        
        rb.velocity += force * Time.deltaTime;
        //Debug.Log(rb.velocity);
        if (rb.velocity.magnitude > maxMagnitude)
        {
            rb.velocity = rb.velocity.normalized * maxMagnitude;
        }
        
    }
    /*
    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider.name);
        if (collider.CompareTag("Pilot"))
        {
            atStation = true;
            stationCollider = collider;
            Debug.Log("Player is at a station!");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Pilot"))
        {
            atStation = false;
            Debug.Log("Player is at a station!");
        }
    }
    */
}
