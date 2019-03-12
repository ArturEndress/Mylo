using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myloScript : MonoBehaviour {

    GameObject player;
    bool found;
    float distance;
    public float fieldOfView;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Animator>().SetBool("found", found);

        distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance > fieldOfView)
        {
            found = false;
        }
        else
        {
            found = true;
        }

        Gizmos.DrawSphere(transform.position, fieldOfView);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(transform.position, fieldOfView);
    }
    

}
