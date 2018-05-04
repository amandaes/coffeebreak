using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCups : MonoBehaviour {

    public GameObject cupsFall;
    float randX; //random x position
    Vector2 whereToSpawn;
    public float spawnRate = 1f;
    float nextSpawn = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-8.36f, 9.4f); //random range of x position
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(cupsFall, whereToSpawn, Quaternion.identity);


        }
    }
}
