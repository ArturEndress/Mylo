using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{

    public AudioClip clip;
    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Enemy")
        {
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bushes")
        {
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}

