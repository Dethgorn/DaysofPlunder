using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // bullet spawn points
    GameObject a, b;
    // sound
    public AudioClip hitClip;

    Rigidbody2D rb;
    // expose some vars
    public float speed;
    public GameObject bullet, explosion;
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
        PlayerPrefs.SetInt("Health", health);
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
        PlayerPrefs.SetInt("Health", health);
        // start blink
        StartCoroutine(Blink());
        AudioSource.PlayClipAtPoint(hitClip, transform.position);
        // when hp runs out, die
        if (health ==0)
        {
            // go boom and die
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
        }
    }

    IEnumerator Blink()
    {
        // blink red once when hit
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    void Shoot()
    {
        // reset the delay and spawn bullets
        delay = 0;
        Instantiate(bullet, a.transform.position, Quaternion.identity);
        Instantiate(bullet, b.transform.position, Quaternion.identity);
    }

    public void AddHealth()
    {
        health++;
        PlayerPrefs.SetInt("Health", health);
    }
}
