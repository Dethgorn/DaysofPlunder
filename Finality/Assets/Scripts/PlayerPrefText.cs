﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefText : MonoBehaviour {

    public string sname;

	// Update is called once per frame
	void Update ()
    {

        GetComponent<Text>().text = PlayerPrefs.GetInt(sname) + "";
	}
}
