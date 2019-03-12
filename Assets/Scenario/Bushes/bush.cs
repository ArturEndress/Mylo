using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bush : MonoBehaviour {

    public GameObject leaves;
    public Transform posBush;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Instantiate(leaves, posBush);
        }
    }

   
}
