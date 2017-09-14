using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {

    public GameObject ship;
    public MeshCollider mc;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Shield:" + collider.name);
        if (ship.GetComponent<ShipManager>().currentGunEnergy > 0)
        {
            mc.enabled = true;
            if (collider.name == "Bullet(Clone)" || collider.name == "Bullet" || collider.name == "Enemy(Clone)" || collider.name == "Enemy")
            {
                Destroy(collider.gameObject);
                ship.GetComponent<ShipManager>().shieldEnergyBar.changeEnergyBar(ship.GetComponent<ShipManager>().currentShieldEnergy -= 1, ship.GetComponent<ShipManager>().maxShieldEnergy);

            }
        } else
        {
            mc.enabled = false;
        }
    }

    public void OnCollisionEnter(Collision collider)
    {
        Debug.Log(collider.contacts.Length);
        foreach(Collision c in collider)
        {
            Debug.Log("Shield:" + c.collider.name);
            if (c.collider.name == "Bullet(Clone)" || c.collider.name == "Bullet")
            {
                Destroy(c.gameObject);
            }
        }

    }
}
