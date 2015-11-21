using UnityEngine;
using System.Collections;

public class Krv : MonoBehaviour {

	// Use this for initialization
		SpriteRenderer sr;
	
	public Rigidbody2D rb;
	void Start () {
		sr = this.GetComponent <SpriteRenderer> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	 
		if (sr.color.a >= 0f)
	 {

		Color32 c32 = (Color32)sr.color;
			sr.color = (Color)new Color32 (c32.r,c32.g,c32.b, (byte)((int)c32.a - 2) );
		

			if (this.transform.position.y < 35f)
				Destroy (this.gameObject);


	}
		else 	Destroy (this.gameObject);

	}
}
