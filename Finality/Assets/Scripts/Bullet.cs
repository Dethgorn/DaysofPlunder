﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int dir = 1;
    public float bSpeed = 6;
    public float bLife;
    Rigidbody2D rb;

    private void Start()
    {
        // bullet deletes itself after 5 seconds
        Destroy(gameObject, bLife);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ChangeDirection()
    {

        dir *= -1;
    }

    public void ChangeColor(Color col)
    {
        GetComponent<SpriteRenderer>().color = col;
    }
	
	// Update is called once per frame
	void Update ()
    {

        rb.velocity = new Vector2(bSpeed * dir, 0);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if moving right, it is a player bullet
        if(dir == 1)
        {
            // if the player bullet hits an enemy
            if (collision.gameObject.tag == "Enemy")
            {
                // hurt the enemy and destroy the bullet
                collision.gameObject.GetComponent<Enemy>().Damage();
                Destroy(gameObject);
            }
        }
        // else (bullet moving left), it is an enemy bullet
        else
        {
            // if it hits the player
            if (collision.gameObject.tag == "Player")
            {
                // hurt the player and destroy the bullet
                collision.gameObject.GetComponent<Player>().Damage();
                Destroy(gameObject);
            }
        }
        
    }
}
