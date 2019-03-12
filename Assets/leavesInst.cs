using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leavesInst : MonoBehaviour {

    public Transform playerPos;
    public GameObject leaves;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="CheckFloor")
        {
            Instantiate(leaves, playerPos);
        }
    }
}
