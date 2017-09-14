using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeLineRenderer : MonoBehaviour {

    public Transform origin;
    public Transform target;
    public List<GameObject> nodes;
    public GameObject nodePrefab;
    public LineRenderer lineRenderer;
    public GameObject lastNode;

    private float distance;
    private int numOfNodes;
    private Vector3 targetDirection;
    private float nodeSize;
    private bool finished = false;

	// Use this for initialization
	void Start () {
        lastNode = this.gameObject;
        Debug.Log(nodePrefab.GetComponent<Renderer>().bounds.size);
        nodeSize = nodePrefab.GetComponent<Renderer>().bounds.size.x;
        distance = Mathf.Abs(Vector3.Distance(target.position, origin.position));
        numOfNodes = (int)distance / (int)nodeSize;
        //distance = distance / numOfNodes;
        //numOfNodes -= 2;
        numOfNodes = 5;
        Debug.Log(distance + ", " + numOfNodes);
        targetDirection = target.position - origin.position;
        targetDirection = targetDirection.normalized;
        //targetDirection = targetDirection.normalized;
        //AddNodes();
        numOfNodes = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if(!finished)
        {
            AddNodes();
        }
        
        //lineRenderer.SetPosition(0, origin.position);
        //lineRenderer.SetPosition(1, target.position);
	}

    public void AddNodes()
    {
        //if (lastNode.transform.position != target.position)
        //{
            if (Vector3.Distance(target.position, lastNode.transform.position) > nodeSize)
            {
                Vector3 newPosition = target.position - lastNode.transform.position;
                newPosition = newPosition.normalized;
                newPosition *= nodeSize;
                newPosition += lastNode.transform.position;
                newPosition.z = 10f;

                GameObject newNode = (GameObject)Instantiate(nodePrefab, newPosition, Quaternion.identity);
                nodes.Add(newNode);
                newNode.name = numOfNodes.ToString();
                newNode.transform.SetParent(origin);

                lastNode.GetComponent<ConfigurableJoint>().connectedBody = newNode.GetComponent<Rigidbody>();
                lastNode = newNode;
                numOfNodes++;
            } else
            {
                lastNode.GetComponent<ConfigurableJoint>().connectedBody = target.GetComponent<Rigidbody>();
                finished = true;
            }
        //}
    
        /*
        float offset = 1 / numOfNodes;
        for (int i = 1; i < numOfNodes; i++)
        {
            Vector3 newPosition = target.position + (origin.position - target.position) * (offset * i);

            Debug.Log(newPosition);

            GameObject newNode = (GameObject)Instantiate(nodePrefab, newPosition, Quaternion.identity);
            nodes.Add(newNode);
            newNode.name = (i).ToString();
            //add the first new node's rigidbody to the origin
            if (nodes.Count == 1)
            {
                origin.GetComponent<ConfigurableJoint>().connectedBody = newNode.GetComponent<Rigidbody>();
                //newNode.transform.position += origin.position;
                //newNode.transform.position *= distance;

            }
            else
            {
                nodes[i-2].GetComponent<ConfigurableJoint>().connectedBody = newNode.GetComponent<Rigidbody>();
                //newNode.transform.position *= distance;
                //newNode.transform.position += nodes[i-1].transform.position;
            }
            //Debug.Log((1f / (float)numOfNodes)* (i+1) + ", " + (i+1));

            //newNode.transform.position = origin.position + targetDirection * distance;

        }
        //set the last node's connected body to the target's rigid body
        nodes[nodes.Count - 1].GetComponent<ConfigurableJoint>().connectedBody = target.GetComponent<Rigidbody>();
        */
    }
    
}
