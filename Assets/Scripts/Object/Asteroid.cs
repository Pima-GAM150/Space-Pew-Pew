using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

    public int health = 1;
    public int ammo = 1;
    public int energy = 3;
    public Rigidbody rb;
    public bool original = true;
    public bool breakApart = false;
    public GameObject prefab;
    public SpriteRenderer renderer;
    public List<GameObject> energyPrefabs;

    private float moveTimer = 0f;
    private float moveAmount = 1.5f;
    private float maxAmmo = 3;
    private float maxEnergy = 3;


    // Use this for initialization
    void Start () {
        energy = Random.Range(1, 4);
        changeColor();
		if(!original)
        {
            rb.velocity += new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), 10f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 10f);
	}

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "Bullet(Clone)" || collider.name == "Bullet")
        {
            if(!original)
            {
                Destroy(collider.gameObject);
                instantiateEnergyAsteroid();
                Destroy(this.gameObject);
            } else
            {
                //break apart
                Destroy(collider.gameObject);
                for(int i = 0; i < 4; i++)
                {
                    instantiateAsteroid(this.transform.position);
                }
                instantiateEnergyAsteroid();
                Destroy(this.gameObject);
            }
        }
    }

    public void instantiateAsteroid(Vector3 position)
    {
        GameObject newAsteroid = (GameObject)Instantiate(prefab, position, Quaternion.identity);
        newAsteroid.GetComponent<Asteroid>().original = false;
        newAsteroid.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void instantiateEnergyAsteroid()
    {
        if (energy > 0)
        {
            for (int i = 0; i < energy; i++)
            {
                int rmd = Random.Range(0, energyPrefabs.Count);
                Debug.Log(rmd);
                GameObject energyAsteroid = (GameObject)Instantiate(energyPrefabs[rmd], this.transform.position, Quaternion.identity);
            }

        }
    }

    public void changeColor()
    {

        //Color color = Color.HSVToRGB(35f/360f, 100f/100f, 55f/100f);
        //Debug.Log(energy / maxEnergy);
        Color color = Color.HSVToRGB(35f / 360f, 100f / 100f, (energy/maxEnergy));
        //RGB for asteroid default color
        //color.r = 142f;
        //color.g = 0f;
        //color.b = 85f;
        renderer.color = color;
        
        //Debug.Log(material.color);
        
    }
}
