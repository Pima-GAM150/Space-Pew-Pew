using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeToCamera : MonoBehaviour {

    public SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        ResizeSpriteToCamera();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResizeSpriteToCamera()
    {
        if(sr == null) { return; }

        float spriteWidth = sr.sprite.bounds.size.x;
        float spriteHeight = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(worldScreenWidth / spriteWidth, worldScreenHeight / spriteHeight, 1f);

        //Center background
        transform.position = new Vector3(0f, 0f, 1f);

    }
}
