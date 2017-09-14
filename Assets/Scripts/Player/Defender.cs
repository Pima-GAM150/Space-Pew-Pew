using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : PlayerClass {

    private float squareTimer = 0f;
    private float squareTimerDuration = 0.2f; //When you hit the square button it sends over a bunch of trues so it is executing multiple times in a row.


    // Use this for initialization
    void Start () {
        ship = GameObject.Find("Ship");
        centerPoint = GameObject.Find("QuarterShieldCenterPoint").gameObject;
        objControlling = GameObject.Find("QuarterShieldCenterPoint").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        squareTimer += Time.deltaTime;
    }

    public override void Circle()
    {
        throw new NotImplementedException();
    }

    public override void Square()
    {
        if (squareTimer > squareTimerDuration)
        {
            Debug.Log("Executing Square!");
            squareTimer = 0f;
            if (!sitting && atStation)
            {
                Debug.Log("Setting sitting to true!");
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

    public override void X()
    {
        throw new NotImplementedException();
    }
}
