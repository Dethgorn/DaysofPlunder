using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    Rigidbody2D rb;

    public GameObject bullet;
    public Color bulletColor;

    // expose vars
    [Header("HP & Life timer")]
    public float health;
    public float lifeTime;

    [Header ("Move Speed/Direction")]
    public float xSpeed;
    public float ySpeed;

    [Header ("Fire Control")]
    public bool canShoot;
    public float fireRate;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        
        // enemies destroy after certain time
        Destroy(gameObject, lifeTime);

        // if canShoot is unchecked
        if (!canShoot)
        {
            // return out
            return;
        }
        else
        {
            // set fire rate and keep shooting
            fireRate = fireRate + (Random.Range(fireRate/-2, fireRate/2));
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
        
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

    void Shoot()
    {

        GameObject temp = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
        temp.GetComponent<Bullet>().ChangeColor(bulletColor);
    }
}
