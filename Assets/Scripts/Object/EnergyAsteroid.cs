using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyAsteroid : MonoBehaviour {

    public GameObject ship;
    public Rigidbody rb;
    public Seek seek;
    public SpriteRenderer renderer;
    public string asteroidKind;
    public float energy;
    public float maxEnergy;

	// Use this for initialization
	void Start () {
        
        rb.velocity += new Vector3(Random.Range(-5, 6), Random.Range(-5, 6), 10f);
        if(asteroidKind == "Gun")
        {
            maxEnergy = 25;
            energy = Random.Range(10, maxEnergy);
            //energy = 25;
        } else if(asteroidKind == "Shield")
        {
            maxEnergy = 10;
            energy = Random.Range(3, maxEnergy);
        } else if(asteroidKind == "Engine")
        {
            maxEnergy = 75;
            energy = Random.Range(25, maxEnergy);
        }
        renderer = gameObject.GetComponent<SpriteRenderer>();
        changeColor();
        ship = GameObject.Find("Ship");
    }
	
	// Update is called once per frame
	void Update () {
        if(ship == null) { ship = GameObject.Find("Ship"); }
        if(this.transform.position.z != 10f)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 10f);
        }

        //Debug.Log(Vector3.Distance(this.transform.position, ship.transform.position));
		if(Vector3.Distance(this.transform.position, ship.transform.position) < 100)
        {
            seek.ApplyForce(seek.seek(ship.transform.position));
        }
	}

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "Ship")
        {
            Destroy(this.gameObject);
        }
    }

    public void changeColor()
    {
        Color color = renderer.color;
        //Color color = Color.HSVToRGB(35f/360f, 100f/100f, 55f/100f);
        //Debug.Log(energy / maxEnergy);
        if (asteroidKind == "Gun")
        {
            color = Color.HSVToRGB(30f / 360f, 100f / 100f, (energy / maxEnergy));
        } else if(asteroidKind == "Shield")
        {
            color = Color.HSVToRGB(64f / 360f, 100f / 100f, (energy / maxEnergy));
        } else if (asteroidKind == "Engine")
        {
            color = Color.HSVToRGB(359 / 360f, 100f / 100f, (energy / maxEnergy));
        }

        renderer.color = color;

        //Debug.Log(material.color);

    }
}
