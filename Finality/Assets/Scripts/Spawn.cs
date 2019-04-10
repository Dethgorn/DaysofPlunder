using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    // expose vars
    public float rate;
    public int waveSize = 1;
    public GameObject[] enemies;
    

	// Use this for initialization
	void Start () {
        // set spawn rate
        InvokeRepeating("Spawner", rate, rate);
	}
	
	// Update is called once per frame
	void Spawner ()
    {
        // spawn more than one enemy at a time, controlled in editor
        for (int i = 0; i < waveSize; i++)
        {
            // make an enemy at 18x somewhere on the y axis and facing left
            Instantiate(enemies[Random.Range(0, enemies.Length)], new Vector3(18, Random.Range(-13, 13), 0), Quaternion.identity);
        }
	}
}
