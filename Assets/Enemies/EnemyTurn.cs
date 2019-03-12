using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : MonoBehaviour {

    public int direction;
    public float spd;
	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x + direction * spd * Time.deltaTime, transform.position.y);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trigger")
        {
            direction *= -1;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;

            Debug.Log("COLIDIU COM: " + collision.tag);
        }
    }
}
