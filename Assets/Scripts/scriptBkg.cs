using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBkg : MonoBehaviour
{

    // Use this for initialization
    public float startOfLine = -100;
    public float endOfLine = 65.4f;
    public float spd;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x - spd * Time.deltaTime, transform.position.y);

        if (transform.position.x <= startOfLine)
        {
            transform.position = new Vector2(endOfLine, transform.position.y);
        }
	}
}
