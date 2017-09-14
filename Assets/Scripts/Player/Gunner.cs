using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : PlayerClass {

    /*
     *Abilities
     * Shoot
     * Boost Movement Speed
     * Laser?
     */
    //private Collider stationCollider;
    private float squareTimer = 0f;
    private float squareTimerDuration = 0.2f; //When you hit the square button it sends over a bunch of trues so it is executing multiple times in a row.

    private float maxSpeed = 5f;
    private float maxMagnitude = 2f;

    // Use this for initialization
    void Start()
    {
        ship = GameObject.Find("Ship");
        centerPoint = GameObject.Find("Turret").gameObject;
        objControlling = GameObject.Find("TurretCenterPoint").gameObject;
        damage = 2;
        objControlling.GetComponent<Shoot>().dmg = damage;
        //className = ClassName.gunner;
    }

    // Update is called once per frame
    void Update()
    {
        squareTimer += Time.deltaTime;
    }

    public override void Circle()
    {
        //shoot bullet
    }

    public override void Square()
    {
        //Debug.Log("SQUARE!");
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
        if(ship.GetComponent<ShipManager>().currentGunEnergy > 0 && sitting)
        {
            objControlling.GetComponent<Shoot>().Fire();
            ship.GetComponent<ShipManager>().gunEnergyBar.changeEnergyBar(ship.GetComponent<ShipManager>().currentGunEnergy -= 1, ship.GetComponent<ShipManager>().maxGunEnergy);
        }

    }

    /*
    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider.name);
        if (collider.CompareTag("Station"))
        {
            atStation = true;
            stationCollider = collider;
            Debug.Log("Player is at a station!");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Station"))
        {
            atStation = false;
            Debug.Log("Player is at a station!");
        }
    }
    */

}
