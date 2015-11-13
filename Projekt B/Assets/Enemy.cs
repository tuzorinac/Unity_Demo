using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public GameObject zastava;
	public Rigidbody2D rb;
	public int mjenjačsmjera;
	BoxCollider2D bc;
	float cofzapeo;
	float time;
	float timecofdrugismer;
	// Use this for initialization
	void Start () {
	

		rb = GetComponent<Rigidbody2D> ();
		bc = GetComponent<BoxCollider2D> ();
		cofzapeo = 1f;
		time = -1f;
		
			
			

	}
	
	// Update is called once per frame

	void FixedUpdate () {

//	<>
		
		float cof;

		if (this.rb.velocity.x == 0f && this.rb.velocity.y  == 0f) {



			if (time == -1f) {
				print ("Palim");
				time = Time.timeSinceLevelLoad;
				

			} else if (time + 1f < Time.timeSinceLevelLoad) {

			print ("Šp");
				

				if (cofzapeo == 1f)
				cofzapeo = -1f;
				else cofzapeo = 1f;
				timecofdrugismer = Time.timeSinceLevelLoad;
				time = -1;
			
			} 

		} 
		else{
			time = -1f;
			print ("Gasim");
		} 
		
		

		if (bc.IsTouchingLayers (1 << LayerMask.NameToLayer ("Zid")) 
			|| bc.IsTouchingLayers (1 << LayerMask.NameToLayer ("Zastava"))) {
			cof = 1f;
		} 

		else
			cof = 0.03f;
		
		if (this.transform.position.x > zastava.transform.position.x)
		{

			print (cof + "cof" + cofzapeo + "cofzapeo");
			rb.AddForce (new Vector2 (-1f,0f) * 0.3f * cof * cofzapeo, ForceMode2D.Impulse );	

		
		
		}
		else if (this.transform.position.x < zastava.transform.position.x)
		{
			print (cof + "cof" + cofzapeo + "cofzapeo");
			
			rb.AddForce (new Vector2 (1f,0f) *0.3f * cof * cofzapeo, ForceMode2D.Impulse );
			
		}


		
	}


}
