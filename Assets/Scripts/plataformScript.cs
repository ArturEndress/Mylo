using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformScript : MonoBehaviour {

    private Vector3 lastFrame;
    //scriptPlayer playerscript;
    GameObject player;
    PlataformSide sidePlatScript;
    float dif, dif2;
    public float vel;
    LayerMask plat;
	// Use this for initialization

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        sidePlatScript = GameObject.FindGameObjectWithTag("Floor").GetComponent<PlataformSide>();
	}
	
	// Update is called once per frame
	void Update () {
        dif = transform.position.x - player.transform.position.x;
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            dif = transform.position.x - player.transform.position.x;

        lastFrame = transform.position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        
        if (collision.tag == "Player")
        {
            //player.transform.position = new Vector2(transform.position.x, player.transform.position.y);
            dif2 = transform.position.x - player.transform.position.x;
            if (dif2 > dif)
            {
                player.transform.position = new Vector2(player.transform.position.x + vel * Time.deltaTime, player.transform.position.y);
            }
            else if (dif2 < dif)
            {
                player.transform.position = new Vector2(player.transform.position.x - vel * Time.deltaTime, player.transform.position.y);
            }
        }
        
    }
    
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        player.transform.parent = null;
    //    }
    //}
}
