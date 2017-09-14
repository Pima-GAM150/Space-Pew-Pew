using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public GameObject turret;
    public float speed = 100f;
    public float lifeSpan = 2f;
    public int dmg = 1;
    public Rigidbody rb;

    private float lifeTime;

	// Use this for initialization
	void Start () {
        //turret = GameObject.Find("CenterPoint");
	}
	
	// Update is called once per frame
	void Update () {
        lifeTime += Time.deltaTime;
        if(lifeTime > lifeSpan)
        {
            Destroy(this.gameObject);
        }
        Move();
	}

    public void Move()
    {
        //rb.velocity += Vector3.forward * speed * 10;
        if(this.gameObject != null)
        {
            Vector3 desired = this.transform.position - turret.transform.position;

            //normalize
            desired.Normalize();
            this.transform.position += desired / speed;
        }


        //Might want to change this to use a rigidbody and add velocity
    }
}
