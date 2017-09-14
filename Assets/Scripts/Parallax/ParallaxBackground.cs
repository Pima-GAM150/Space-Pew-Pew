using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

    public MeshRenderer mr;
    public Rigidbody rb;
    public Transform shipTransform;
    private Material material;

    void Start()
    {
        material = mr.material;
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 offset = material.mainTextureOffset;
        offset -= (rb.velocity.normalized * rb.velocity.magnitude/5 * Time.deltaTime * 0.1f);
        material.mainTextureOffset = offset;
		
	}
}
