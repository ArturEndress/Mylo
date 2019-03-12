using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChekFloorScript : MonoBehaviour {

    scriptPlayer scriptPlayer;
    public int maxJumps;
    public GameObject dust;
    public Transform dustPos;
    //public Particle dust;
    

	// Use this for initialization
	void Start () {
        scriptPlayer = GetComponentInParent<scriptPlayer>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.tag == "Floor")
        {
            scriptPlayer.onGround = false;
           
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            Vector3 pos = dustPos.position;

            //dustPos.position = new Vector2(transform.position.x, transform.position.y);
            Instantiate(dust, pos, Quaternion.identity);

            scriptPlayer.somsource.PlayOneShot(scriptPlayer.steps);

            scriptPlayer.onGround = true;

            scriptPlayer.jumpCounter = maxJumps;
            scriptPlayer.jumpAccel = -1;

        }

        if (collision.tag == "Life")
        {
            Destroy(collision.gameObject);
            if (GetComponentInParent<scriptPlayer>().health < 4)
            {
                GameObject.Find("Hp" + GetComponentInParent<scriptPlayer>().health).GetComponent<Image>().enabled = false;
                GetComponentInParent<scriptPlayer>().health++;
            }
        }
    }
}
