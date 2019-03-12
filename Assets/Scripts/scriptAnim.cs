using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptAnim : MonoBehaviour {

    public GameObject leaves;
    //public Transform posBush;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<Animator>().SetTrigger("touched");
            Instantiate(leaves, transform.position, Quaternion.identity);
        }
        
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        GetComponent<Animator>().SetTrigger("touched");
    //    }
    //}
}
