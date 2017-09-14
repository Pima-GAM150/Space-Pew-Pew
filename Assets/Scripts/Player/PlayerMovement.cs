using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Vector2 movePosition = Vector2.zero;

    private bool climbing = false;
    private float ladderXpos;
    private float speed = 2f;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = this.gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("movePosition: " + movePosition);
        //MovePlayer(movePosition.x, movePosition.y);	
	}

    void FixedUpdate()
    {
        MovePlayer(movePosition.x, movePosition.y);
    }

    public void MovePlayer(float x, float y)
    {
        
        /*
        if(climbing)
        {
            if (x == 0 && y == 0)
            {
                Vector3 newPosition = transform.position += new Vector3(0, 0, 0);
                newPosition.z = 10f;
                transform.position = newPosition;
            }
            else
            {
                Vector3 newPosition = transform.position += new Vector3(x/2, y, 0);
                newPosition.z = 10f;
                transform.position = newPosition;
            }
        } else
        {
            if (x == 0 && y == 0)
            {
                Vector3 newPosition = transform.position += new Vector3(0, 0, 0);
                newPosition.z = 10f;
                transform.position = newPosition;
            }
            else
            {
                Vector3 newPosition = transform.position += new Vector3(x, y, 0);
                newPosition.z = 10f;
                transform.position = newPosition;
            }
        }
        */
        if (climbing)
        {

            Vector3 newPosition = transform.position += new Vector3((x / 2) / speed, y, 0);
            newPosition.z = 10f;
            //transform.position = newPosition;
            //newPosition.z = 0;
            Vector3.Lerp(transform.position, newPosition, Time.time);

        }
        else
        {
            Vector3 newPosition = transform.position += new Vector3(x / speed, y / speed, 0);
            newPosition.z = 10f;
            //transform.position = newPosition;
            //newPosition.z = 0f;
            rb.MovePosition(transform.position + new Vector3(x / speed, y / speed, 0) * Time.deltaTime);
            //Vector3.Lerp(transform.position, newPosition, Time.time);
        }



    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Ladder"))
        {
            //Debug.Log("Climbing is now true!");
            climbing = true;
            ladderXpos = collider.transform.position.x;
            transform.position = new Vector3(ladderXpos, transform.position.y, 10f);
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;

        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Ladder"))
        {
            //Debug.Log("Climbing is now false!");
            climbing = false;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
