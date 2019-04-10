using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // bullet spawn points
    GameObject a, b;

    Rigidbody2D rb;
    // expose some vars
    public float speed;
    public GameObject bullet;
    int delay = 0;
    public int shotDelay = 5;
    public int health =3;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // get the bullet spawners
        a = transform.Find("a").gameObject;
        b = transform.Find("b").gameObject;
    }

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        // move
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));

        // hold down space to shoot, build in a delay
        if (Input.GetKey(KeyCode.Space) && delay > shotDelay)
        {
            // shoot function
            Shoot();
        }
        delay++;
    }

    public void Damage()
    {
        // hp -1
        health--;
        // when hp runs out, die
        if(health ==0)
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        // reset the delay and spawn bullets
        delay = 0;
        Instantiate(bullet, a.transform.position, Quaternion.identity);
        Instantiate(bullet, b.transform.position, Quaternion.identity);
    }
}
