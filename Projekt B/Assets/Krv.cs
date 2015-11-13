using UnityEngine;
using System.Collections;

public class Krv : MonoBehaviour {

	// Use this for initialization

	public Rigidbody2D rb;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 

			if (this.transform.position.y < 33f)
				Destroy (this.gameObject);


	}
}
