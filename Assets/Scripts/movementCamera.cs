using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.x, transform.position.y);
	}
}
