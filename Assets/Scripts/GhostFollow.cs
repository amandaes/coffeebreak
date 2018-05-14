using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GhostFollow : MonoBehaviour {

    public Transform target;
    public float maxDistanceFromPlayer;
    public float speed;


	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector2.Distance(transform.position, target.position)< maxDistanceFromPlayer)
        {
            //SoundEffect.PlaySound("Ghostly");
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);

            
        }


	}

}
