﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehavior : MonoBehaviour {

    public Sprite[] sprites;
    public float playerSpeed;
    private bool disabled; //player disable movement
    public CountdownTime myInstanceOfCountdowntime;

    public GameObject playerSpeech;
    public GameObject broken;
    public float killSpeech = 4f; 

    //public GameObject speechBub;
    //public Transform peerPos;

    Rigidbody2D rb;
    SpriteRenderer sr;

	// Use this for initialization
	public void Start () {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        disabled = false; //not disabled at start of the game
        //canMove = true;
	}

    // Update is called once per frame
    public void Update () {

        if (disabled == false)
        {

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-playerSpeed, rb.velocity.y);
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
            }

            else
            {
                rb.velocity = new Vector2(0.0f, rb.velocity.y);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, -playerSpeed);
            }

            else if (Input.GetKey(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, playerSpeed);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            }

        }
        //make transition of idle animation to walking animation with boolean 
        if(rb.velocity.magnitude > 0.01f)
        {
            GetComponent<Animator>().SetBool("isWalking", true);

        }

        if(rb.velocity.magnitude <= 0.01f)
        {
            GetComponent<Animator>().SetBool("isWalking", false);
        }


    }
    public void OnTriggerEnter2D(Collider2D peerCol)
    {
        if (peerCol.gameObject.tag == "Peers")
        {
            disabled = true;
            rb.velocity = new Vector2(0f, 0f);
            Invoke("ResetDisabled", 4.0f); //after 4 seconds call ResetDisabled()
            peerCol.gameObject.SendMessage("DisablePeers");

            GameObject newplayerTalk = Instantiate(playerSpeech);
            newplayerTalk.transform.position = new Vector2(transform.position.x - 0.8f, transform.position.y + 1.2f);
            Destroy(newplayerTalk, killSpeech); //destroy the speech bubble after killspeech time
        }

            switch (peerCol.gameObject.tag)
            {
                case "plus3":

                SoundEffect.PlaySound("ClockTick");

                myInstanceOfCountdowntime.startingTime += 3f;
                    peerCol.gameObject.SetActive(false);
                    break;

                case "ghost":
                SceneManager.LoadScene(4);

                break;

                case "Broken":
                GameObject brokenSpeech = Instantiate(broken);
                brokenSpeech.transform.position = new Vector2(transform.position.x - 0.8f, transform.position.y + 1.2f);
                Destroy(brokenSpeech, 2f);
                break;

            }
    }

    void ResetDisabled()
    {
        disabled = false;
    }

}
