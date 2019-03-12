using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scriptPlayer : MonoBehaviour {
    public float spd;
    public Rigidbody2D rb;
    public Transform checkpoint;
   
    float direction;
    public int jumpCounter, health, maxHealth;
    public float currentHeight;
    public float jumpHeight;
    public float jumpAccel, jumpSpd, maxAccel, accel;
    public bool onGround;
    public bool canHurt;
    public float cooldown, clock;
    public bool isWalking;

    public bool died;

    public AudioSource somsource;
    public AudioClip som, bushes, landing, dmg, steps;

    private Vector3 lastFrame;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
       
        canHurt = true;
        cooldown = clock;
        died = false;
        maxHealth = health;

        
    }
	
	
	void Update () {

        if(health < 4)
            GameObject.Find("Hp" + health).GetComponent<Image>().enabled = true;

        if (died)
        {
            //GetComponent<SpriteRenderer>().enabled = true;
            //GetComponent<Animator>().SetTrigger("died");
            //StartCoroutine(Reset());
            GetComponent<SpriteRenderer>().enabled = true;
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                SceneManager.LoadScene("play");
                //Reset();
                cooldown = clock;
            }
            return;
            //cooldown -= Time.deltaTime;
            //if (cooldown <= 0)
            //{
            //    cooldown = clock;
            //    Reset();
            //}
        }
        //if (died) return;


        //if (health < 4)
        //{
        //    GameObject.Find("Hp" + health).SetActive(true);
        //}


        
            if (health <= 0)
            {

            //GameObject.Find("Hp" + health).SetActive(true);
            GetComponent<Animator>().SetTrigger("died");
            died = true;
            cooldown = clock;
            }

            direction = Input.GetAxisRaw("Horizontal");

            GetComponent<Animator>().SetBool("isWalking", isWalking);

            if (direction == 1)
            {
                isWalking = true;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (direction == -1)
            {
                isWalking = true;
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                isWalking = false;
            }


        //Frames Invenc


        GetComponent<Animator>().SetInteger("jumps", jumpCounter);

            if (!canHurt)
            {
                cooldown -= Time.deltaTime;
                if (cooldown <= 0)
                {
                    canHurt = true;
                    cooldown = clock;
                }
                GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
            }
            else
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }



            // MOVEMENT
            rb.MovePosition(new Vector2(transform.position.x + direction * spd * Time.deltaTime, transform.position.y + jumpAccel * Time.deltaTime));


        //JUMP
        if (Input.GetKey(KeyCode.Space))// && transform.position.y - currentHeight < currentHeight + jumpHeight)
        {
            if (jumpCounter >= 1)
            {

                if (Input.GetKeyDown(KeyCode.Space))
                {

                    somsource.PlayOneShot(som);
                    jumpCounter--;
                    currentHeight = transform.position.y;
                    jumpAccel = jumpSpd;
                    rb.AddForce(new Vector2(0, jumpSpd));

                    GetComponent<Animator>().SetTrigger("jump");
                }

            }
            if (!onGround)
            {
                if (jumpAccel >= -maxAccel)
                {
                    jumpAccel -= accel * Time.deltaTime;
                }
            }
            //else
            //{
            //    jumpAccel = -1;
            //}
        }
        else
        {
            if (!onGround)
            {
                if (jumpAccel >= -maxAccel)
                {
                    jumpAccel -= accel * Time.deltaTime;


                }
            }
            else
            {
                jumpAccel = 0;

            }

        }

    }
    private void Reset()
    {
        //GameObject.Find("Panel").GetComponent<Animator>().SetTrigger("fadeIn");
        //yield return new WaitForSeconds(2f);

        transform.position = checkpoint.position;
        health = maxHealth;
        died = false;
        canHurt = true;

        for (int i = 0; i < 4; i++)
        {
            GameObject.Find("Hp" + i).GetComponent<Image>().enabled = false;
        }



    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canHurt)
        {
            if (collision.tag == "Enemy")
            {
                canHurt = false;
                health--;
                somsource.PlayOneShot(dmg);
            }
        }
        if (collision.name == "sideElevatorChild")
        {
            // transform.position = new Vector2(transform.position.x + sidePlatScript.dir * sidePlatScript.spd * Time.deltaTime, transform.position.y);
            transform.position += collision.transform.position - lastFrame;
            lastFrame = collision.transform.position;

            //GameObject.Find("sideElevatorChild").GetComponent<PlataformSide>();
            // transform.position = new Vector2(transform.position.x + GameObject.Find("sideElevatorChild").GetComponent<PlataformSide>().dir  * Time.deltaTime, transform.position.y);



            Debug.Log("Colidiu com: " + collision.name);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Cliff")
        {
            died = true;
        }
        if (collision.name == "sideElevatorChild")
        {
            lastFrame = collision.transform.position;
        }
        if (collision.tag == "Bushes")
        {
            somsource.PlayOneShot(bushes);
        }
        if (collision.tag == "Mylo")
        {
            SceneManager.LoadScene("menu");
        }
        if (collision.tag == "Water")
        {
            somsource.PlayOneShot(dmg);
        }
       

    }

    
    public void Step()
    {
        somsource.PlayOneShot(steps);
    }
}
