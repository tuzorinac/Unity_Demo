﻿using UnityEngine;
using System.Collections;

public class Metak : MonoBehaviour {


	float timeout;

	// Use this for initialization
	void Start () {
		timeout = Time.timeSinceLevelLoad;
	}
	
	// Update is called once per frame
	void FixedUpdate () {



		if (timeout < Time.timeSinceLevelLoad - 2.5f)
			Destroy (this.gameObject);
			
	}
}
