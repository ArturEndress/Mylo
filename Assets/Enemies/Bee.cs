using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour {

    public float spd;
    public int dirVert, dirHor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector2(transform.position.x + dirHor * spd * Time.deltaTime, transform.position.y + dirVert * spd * Time.deltaTime);

	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TriggerUp")
        {
            dirVert *= -1;
        }
        if (collision.tag == "TriggerSide")
        {
            dirHor *= -1;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }
    }
}
