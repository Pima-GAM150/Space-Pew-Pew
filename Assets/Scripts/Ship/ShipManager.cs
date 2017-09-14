using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipManager : MonoBehaviour {

    public string reloadScene;
    public int killCount = 0;
    public int shipHealth = 10;
    public float maxShieldEnergy = 50f;
    public float maxGunEnergy = 100f;
    public float maxEngineEnergy = 250f;
    public float currentShieldEnergy = 50f;
    public float currentGunEnergy = 100f;
    public float currentEngineEnergy = 100f;
    public Text hpText;
    public ShipEnergybar shieldEnergyBar;
    public ShipEnergybar gunEnergyBar;
    public ShipEnergybar engineEnergyBar;
    public Text shieldEnergyPopupText;
    public Text gunEnergyPopupText;
    public Text engineEnergyPopupText;

    private float textFadeTimer = 2f;
    private float shieldTextTimer = 0f;
    private float gunTextTimer = 0f;
    private float engineTextTimer = 0f;

	// Use this for initialization
	void Start () {
        hpText = GameObject.Find("HP").GetComponent<Text>();
        hpText.text = "HP: " + shipHealth.ToString();
        shieldEnergyPopupText.rectTransform.localPosition = new Vector3(shieldEnergyBar.transform.position.x -125, shieldEnergyBar.transform.position.y+105, shieldEnergyBar.transform.position.z);
        gunEnergyPopupText.rectTransform.localPosition = new Vector3(gunEnergyBar.transform.position.x +150, gunEnergyBar.transform.position.y - 185, gunEnergyBar.transform.position.z);
        engineEnergyPopupText.rectTransform.localPosition = new Vector3(engineEnergyBar.transform.position.x + 265, engineEnergyBar.transform.position.y + 105, engineEnergyBar.transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        shieldTextTimer += Time.deltaTime;
        gunTextTimer += Time.deltaTime;
        engineTextTimer += Time.deltaTime;
        if (shieldTextTimer > textFadeTimer) { shieldEnergyPopupText.text = ""; }
        if (gunTextTimer > textFadeTimer) { gunEnergyPopupText.text = ""; }
        if (engineTextTimer > textFadeTimer) { engineEnergyPopupText.text = ""; }
    }

    public void takeDamage(int dmg)
    {
        shipHealth -= dmg;
        hpText.text = "HP: " + shipHealth.ToString();
        if (shipHealth <= 0)
        {
            Debug.Log("Ship died!");
            //Add a game over screen
            //and button
            //reset everything back to starting position

            SceneManager.LoadScene(reloadScene, LoadSceneMode.Single);
            //Destroy(this.gameObject);
        }
    }

    public void setCurrentGunEnergy(float currentEnergy) { this.currentGunEnergy = currentEnergy; }
    public float getCurrentGunEnergy() { return currentGunEnergy; }

    public void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider.gameObject.name);
        if (collider.name == "Bullet(Clone)")
        {
            Destroy(collider.gameObject);
            //lose hp or get destroyed
            takeDamage(collider.gameObject.GetComponent<BulletMove>().dmg);
        }
        else if (collider.name == "Enemy(Clone)")
        {
            takeDamage(1);
        }
        else if (collider.name == "GunEnergyAsteroid(Clone)" || collider.name == "GunEnergyAsteroid")
        {
            string energyName = collider.GetComponent<EnergyAsteroid>().asteroidKind;
            currentGunEnergy += collider.GetComponent<EnergyAsteroid>().energy;
            gunEnergyPopupText.text = "+" + ((int)collider.GetComponent<EnergyAsteroid>().energy).ToString();
            gunTextTimer = 0f;
            if (currentGunEnergy > maxGunEnergy)
            {
                currentGunEnergy = maxGunEnergy;
            }
        }
        else if (collider.name == "ShieldEnergyAsteroid(Clone)" || collider.name == "ShieldEnergyAsteroid")
        {
            currentShieldEnergy += collider.GetComponent<EnergyAsteroid>().energy;
            shieldEnergyPopupText.text = "+" +((int)collider.GetComponent<EnergyAsteroid>().energy).ToString();
            shieldTextTimer = 0f;
            if (currentShieldEnergy > maxShieldEnergy)
            {
                currentShieldEnergy = maxShieldEnergy;
            }
        }
        else if (collider.name == "EngineEnergyAsteroid(Clone)" || collider.name == "EngineEnergyAsteroid")
        {
            currentEngineEnergy += collider.GetComponent<EnergyAsteroid>().energy;
            engineEnergyPopupText.text = "+" + ((int)collider.GetComponent<EnergyAsteroid>().energy).ToString();
            engineTextTimer = 0f;
            if (currentEngineEnergy > maxEngineEnergy)
            {
                currentEngineEnergy = maxEngineEnergy;
            }
        }

    }

    public void OnCollision(Collision collider)
    {
        if(collider.gameObject.name == "Ship")
        {
            takeDamage(1);
        }
    }
}
