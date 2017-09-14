using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour {

    public GameObject prefab;
    public Transform shipLocation;
    public int numberOfObstacles = 10;
    public float maxDistance = 50f;
    public List<GameObject> obstacles;

	// Use this for initialization
	void Start () {
        shipLocation = GameObject.Find("Ship").GetComponent<Transform>();
		for(int i = 0; i < numberOfObstacles; i++)
        {
            instaniateObstacles();
        }
        instaniateObstacles(new Vector3(shipLocation.transform.position.x + 10, shipLocation.transform.position.y, shipLocation.transform.position.z));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void instaniateObstacles()
    {
        float ang = Random.value * 360;
        Vector2 pos;
        float newRadius = Random.Range(50, maxDistance);
        pos.x = shipLocation.position.x + newRadius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = shipLocation.position.y + newRadius * Mathf.Cos(ang * Mathf.Deg2Rad);
        GameObject newObstacle = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
        obstacles.Add(newObstacle);
    }

    public void instaniateObstacles(Vector3 startPosition)
    {
        GameObject newObstacle = (GameObject)Instantiate(prefab, startPosition, Quaternion.identity);
        obstacles.Add(newObstacle);
    }
}
