using UnityEngine;
using System.Collections;

public class Lik : MonoBehaviour {


	Rigidbody2D rb;
	public BoxCollider2D noge;
	
	public LayerMask lm;
	float cof;
	float maxvelocityx;
	// Use this for initialization
	void Start () {
	
		noge = GetComponent <BoxCollider2D> ();
		rb = GetComponent<Rigidbody2D> ();
		maxvelocityx = 17f;
	}
	
	// Update is called once per frame
	void Update () {
	
	


	}

	 void FixedUpdate()
	{
	
		if (noge.IsTouchingLayers (1 << LayerMask.NameToLayer ("Zid"))) {
			cof = 1f;
			if (Input.GetKey (KeyCode.Space)&& (noge.IsTouchingLayers (1 << LayerMask.NameToLayer ("Zid")))
			    && rb.velocity.y == 0f) {
				
				rb.AddForce (new Vector2 (0f, 250f) * 4f, ForceMode2D.Force);		}
		} 
		else
			cof = 0.5f;
		
		if (Input.GetKey (KeyCode.RightArrow) && !(rb.velocity.x >maxvelocityx))

			rb.AddForce (new Vector2 (1, 0) * 0.45f *cof, ForceMode2D.Impulse );	
		

		
		if (Input.GetKey (KeyCode.LeftArrow) && !(rb.velocity.x < -maxvelocityx))
			rb.AddForce (new Vector2 (-1,0) * 0.45f * cof, ForceMode2D.Impulse );	



	}
}
