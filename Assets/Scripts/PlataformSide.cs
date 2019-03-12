using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformSide : MonoBehaviour {
    public int dir = 1;
    public float spd;
    Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        rb.MovePosition(new Vector2(transform.position.x + dir * spd * Time.deltaTime, transform.position.y));
        
        
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Trigger")
        {
            dir *= -1;
        }    
    }
    
}
