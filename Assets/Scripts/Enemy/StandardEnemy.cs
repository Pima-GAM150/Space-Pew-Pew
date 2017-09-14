using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : Enemy {

    public Seek seek;
    public LookAt lookAt;
    public Transform target;
    public Shoot shoot;
    public float shootDistance = 50f;

	// Use this for initialization
	void Start () {
        health = 2;
        shoot.dmg = 1;
	}
	
	// Update is called once per frame
	void Update () {
        seek.ApplyForce(seek.seek(target.position));
        lookAt.lookWhereMoving(target.position);
        transform.position = new Vector3(transform.position.x, transform.position.y, 10f);

        if(Mathf.Abs(Vector3.Distance(target.position, this.transform.position)) < shootDistance)
        {
            shoot.Fire();
        }

	}

    public override void takeDamage(int dmg)
    {
        health -= dmg;
        if(health <= 0)
        {
            Debug.Log("Enemy died!");
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
        if(collider.name == "Bullet(Clone)")
        {
            Destroy(collider.gameObject);
            //lose hp or get destroyed
            takeDamage(collider.gameObject.GetComponent<BulletMove>().dmg);
        } else if(collider.name == "Ship" || collider.name == "Circle")
        {
            Destroy(this.gameObject);
        }
    }


}
