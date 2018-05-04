using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeerBehavior : MonoBehaviour {

    private bool disabled;
    public float walkSpeed;
    public bool verticalWalk;
    public float speechTime;

    public GameObject speechBub;
    

    // Use this for initialization
    public void Start () {
        disabled = false;
     
	}
	
	// Update is called once per frame
	public void Update () {
        //making the enemy move left to right or up and down

        if (disabled == false)
        {
            if (verticalWalk == true) //if walking vertical is true do this 
            {
                transform.Translate(new Vector3(0, walkSpeed, 0) * Time.deltaTime);
            }
            else //if not then walk horizontally
            {
                transform.Translate(new Vector3(walkSpeed, 0, 0) * Time.deltaTime);
            }
        }
    }

    public void DisablePeers()
    { //this gets called by the player
        disabled = true;
        Invoke("ResetDisabled", 5.0f); //after 5 seconds call ResetDisabled()
    }

    void ResetDisabled()
    {
        disabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if the enemy collide with game objects taged Immovables then mirror movement
        if (collision.gameObject.tag == "Immovables")
        {
            walkSpeed *= -1;
        }
        
        switch (collision.gameObject.tag)
        {
            case "Player":
                GameObject newSpeech = Instantiate(speechBub);
                newSpeech.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y + 1.5f);

                Destroy(newSpeech, speechTime);
                
                Debug.Log ("TOUCHING");
                break;
        }
    }
}
