using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerClass : MonoBehaviour {

    public ClassName className;
    public float powerLevel = 1; //This is the number of the station they sit at (1 = 1, 2 = 1.25, 3 = 1.5)
    public GameObject objControlling; //Engine, gun, shield,...etc that the player is controlling
    public GameObject centerPoint; //Center point of the ship that everything rotates around
    public GameObject ship;

    //character stats
    public int health;
    public int stamina;
    public int damage;
    public int energy; //how often they can use their abilities

    public bool atStation = false;
    public bool sitting = false;

    public abstract void Square();
    public abstract void Triangle();
    public abstract void Circle();
    public abstract void X();

    public Collider stationCollider;

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider.name);
        if (collider.CompareTag("Pilot"))
        {
            this.gameObject.GetComponent<Pilot>().enabled = true; ;
            atStation = true;
            stationCollider = collider;
            Debug.Log("Player is at a pilot station!");
        }
        else if (collider.CompareTag("Gunner"))
        {
            this.gameObject.GetComponent<Gunner>().enabled = true; ;
            atStation = true;
            stationCollider = collider;
            Debug.Log("Player is at a gunner station!");
        }
        else if (collider.CompareTag("Defender"))
        {
            this.gameObject.GetComponent<Defender>().enabled = true; ;
            atStation = true;
            stationCollider = collider;
            Debug.Log("Player is at a defender station!");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Pilot"))
        {
            this.gameObject.GetComponent<Pilot>().enabled = false;
            atStation = false;
            Debug.Log("Player is leaving a pilot station!");
        }
        else if (collider.CompareTag("Gunner"))
        {
            this.gameObject.GetComponent<Gunner>().enabled = false;
            atStation = false;
            Debug.Log("Player is leaving a gunner station!");
        }
        else if (collider.CompareTag("Defender"))
        {
            this.gameObject.GetComponent<Defender>().enabled = false;
            atStation = false;
            Debug.Log("Player is leaving a defender station!");
        }
    }

}

public enum ClassName
{
    pilot = 1,
    gunner = 2,
    defender = 3
    //whatever the last class will be
}
