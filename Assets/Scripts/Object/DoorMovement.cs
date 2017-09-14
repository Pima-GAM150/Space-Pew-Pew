using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour {

    public GameObject door;
    public float closedDoor;
    public float openedDoor;
    public float increment = 0.005f; //0.01f is a little fast

    private bool isDoorOpen = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(isDoorOpen)
        {
            openDoor();
        } else
        {
            closeDoor();
        }

	}

    private void openDoor()
    {
        if(door.GetComponent<RectTransform>().localScale.y > closedDoor)
        {
            door.GetComponent<RectTransform>().localScale -= new Vector3(0f, increment, 0f);
        }
    }

    private void closeDoor()
    {
        if (door.GetComponent<RectTransform>().localScale.y < openedDoor)
        {
            door.GetComponent<RectTransform>().localScale += new Vector3(0f, increment, 0f);
        }
    }



    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider.name);
        if(collider.CompareTag("Player"))
        {
            Debug.Log("Player open the door!");
            isDoorOpen = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Player closed the door!");
            isDoorOpen = false;
        }
    }
}
