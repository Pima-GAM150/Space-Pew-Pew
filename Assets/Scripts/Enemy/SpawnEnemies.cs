using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemies : MonoBehaviour {

    public List<GameObject> prefabs;
    public List<GameObject> spawnedEnemies;
    public List<GameObject> spawnLocations;
    public int waveCount = 0;
    public Text waveTimer;
    public GameObject shipCenterPoint;

    private bool waveOn = false;
    private float timeBetweenWaves = 45;
    private float timeTillWave = 0f;
    private int numberOfEnemies = 3;
    private string[] locationNames = {"NorthSpawn", "NorthEastSpawn", "EastSpawn", "SouthEastSpawn", "SouthSpawn", "SouthWestSpawn", "WestSpawn", "NorthWestSpawn"};


	// Use this for initialization
	void Start () {
        waveTimer = GameObject.Find("WaveTimer").GetComponent<Text>();
        shipCenterPoint = GameObject.Find("ShipCenterPoint");
        //waveTimer.gameObject.GetComponent<RectTransform>().position = shipCenterPoint.transform.position;
        waveTimer.transform.localPosition = shipCenterPoint.transform.localPosition;
        waveTimer.transform.position = new Vector3(waveTimer.transform.position.x +75, waveTimer.transform.position.y, waveTimer.transform.position.z);

        numberOfEnemies = 3;
        foreach(string name in locationNames)
        {
            spawnLocations.Add(GameObject.Find(name));
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        //if (waveTimer == null) { waveTimer = GameObject.Find("WaveTimer").GetComponent<Text>(); }
        waveTimer.text = "" + ((int)timeBetweenWaves - (int)timeTillWave).ToString();
        //Debug.Log("timeTillWave: " + timeTillWave);
        checkForNulls();
        if(!waveOn) { timeTillWave += Time.deltaTime; }
        if(timeTillWave > timeBetweenWaves)
        {
            waveOn = true;
            numberOfEnemies = Random.Range(3 + waveCount, 7 + waveCount);
            timeTillWave = 0f;
            Random rmd = new Random();
            int rmdInt = Random.Range(1, spawnLocations.Count);
            Transform location = spawnLocations[rmdInt].transform;
            for(int i = 0; i < numberOfEnemies; i++)
            {
                float ang = Random.value * 360;
                float radius = 10f;
                Vector2 pos;
                pos.x = location.position.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
                pos.y = location.position.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
                instaniateEnemy(prefabs[0], pos);
            }
            waveCount++;
            timeBetweenWaves = Random.Range(45, 90);
            waveTimer.enabled = false;
        }
        if(spawnedEnemies.Count == 0)
        {
            waveOn = false;
            if(!waveTimer.enabled)
            {
                waveTimer.enabled = true;
            }
        }
	}

    public void instaniateEnemy(GameObject prefab, Vector2 location)
    {
        GameObject newEnemy = (GameObject)Instantiate(prefab, location, Quaternion.identity);
        newEnemy.GetComponent<StandardEnemy>().target = GameObject.Find("Ship").transform;
        spawnedEnemies.Add(newEnemy);
    }

    public void checkForNulls()
    {
        foreach (GameObject obj in spawnedEnemies)
        {
            if (obj == null)
            {
                spawnedEnemies.Remove(obj);
            }
        }
    }
}
