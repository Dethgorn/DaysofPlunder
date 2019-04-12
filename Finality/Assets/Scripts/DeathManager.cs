using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour {

    GameObject player;
    bool gameOver = false;

	// Use this for initialization
	void Start ()
    {

        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
        if(player == null && !gameOver)
        {

            GameOver();
        }
	}

    void GameOver()
    {

        gameOver = true;
        StartCoroutine(LoadGameOver());
    }

    IEnumerator LoadGameOver()
    {

        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }
}
