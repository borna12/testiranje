﻿using UnityEngine;
using System.Collections;

public class exitApplication : MonoBehaviour {


	// Update is called once per frame
	void Update () {

if (Input.GetKeyDown(KeyCode.Escape) == true)
{
Application.Quit();
}
	}
}
