using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
{
    public float lifeTime;
    public GameObject bullet;
}

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public GameObject centralPoint;
    public Transform bulletSpawnPoint;
    public List<Bullet> bulletsList;
    public float decayTimer = 2f;
    public float fireRate = 0.5f;
    public int dmg;

    private float fireTimer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        fireTimer += Time.deltaTime;
        /*
		foreach(Bullet bul in bulletsList)
        {
            bul.lifeTime += Time.deltaTime;
            if(bul.lifeTime > decayTimer)
            {
                Destroy(bul.bullet);
                bulletsList.Remove(bul);
                //might need to add garbage clean up here for the class hanging around
            }
        }
        */
	}

    public void Fire()
    {
        if(fireTimer > fireRate)
        {
            Bullet bul = new Bullet();
            bul.bullet = (GameObject)Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            bul.bullet.GetComponent<BulletMove>().turret = centralPoint;
            bul.bullet.GetComponent<BulletMove>().dmg = dmg;
            //bulletsList.Add(bul);
            bul.lifeTime = 0;
            //bul.bullet.transform.parent = turret.transform;
            fireTimer = 0f;
        }
    }
}
