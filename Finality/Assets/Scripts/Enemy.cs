using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Rigidbody2D rb;

    // expose vars
    public float xSpeed;
    public float ySpeed;

    public bool canShoot;
    public float fireRate;

    public float health;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
        // move it
        rb.velocity = new Vector2(xSpeed, ySpeed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // if the player bumps an enemy ship
        if(col.gameObject.tag == "Player")
        {
            // hurt the player, kill the enemy
            col.gameObject.GetComponent<Player>().Damage();
            Die();
        }
    }

    public void Damage()
    {
        // health -1
        health--;

        // if hp runs out, call die
        if(health==0)
        {
            Die();
        }
    }

    void Die()
    {
        // boom!
        Destroy(gameObject);
    }
}
