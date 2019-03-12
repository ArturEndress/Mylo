using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{

    public float speed = 0.15f;
    private Transform posPlayer;

    public bool maxMin;
    public float xMin;
    public float yMin;
    public float xMax;
    public float yMax;


    void Start()
    {
        posPlayer = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void Update()
    {

        if (posPlayer)
        {
            // linear interpolation

            //transform.position = Vector3.Lerp(transform.position, posPlayer.position, speed) + new Vector3(0, 0, 0);
            transform.position = Vector2.Lerp(transform.position, posPlayer.position, speed);

            //transform.position = Vector3.Lerp(transform.position, posPlayer.position, speed) + new Vector3(0, 0, posPlayer.position.z);

            if (maxMin)
            {
                transform.position = new Vector3(Mathf.Clamp(posPlayer.position.x, xMin, xMax), Mathf.Clamp(posPlayer.position.y, yMin, yMax), 2 * posPlayer.position.z);

            }

        }

    }
}
