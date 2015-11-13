using UnityEngine;
using System.Collections;

public class Enemyv2 : MonoBehaviour {
	static float zastava;
	Rigidbody2D rb;
	BoxCollider2D bc;
	float cofzapeo;
	float time;
	float timecofdrugismer;
	bool pada = true;
	static float speed;
	PolygonCollider2D pc;
	public GameObject score;
	bool killed;
	public Sprite deadsprite;
	public GameObject Krvmodel;
	static float krvjačina;
	void Promjenismjerpopotrebi ()
	{
		if (this.rb.velocity.x == 0f && this.rb.velocity.y == 0f && !pada) {
			if (cofzapeo == 1f)
				cofzapeo = -1f;
			else
				cofzapeo = 1f;
		}
		else if (this.rb.velocity.y < 0f)
				pada = true;
		else if (pada) {
					pada = false;
					cofzapeo = 1f;
				}
	}

	void Pokrenise (float cof)
	{
		if (this.transform.position.x > zastava) {
			//	print (cof + "cof" + cofzapeo + "cofzapeo");
			rb.AddForce (new Vector2 (-1f, 0f) * speed * cof * cofzapeo, ForceMode2D.Impulse);
		}
		else
			if (this.transform.position.x < zastava) {
				//	print (cof + "cof" + cofzapeo + "cofzapeo");
				rb.AddForce (new Vector2 (1f, 0f) * speed * cof * cofzapeo, ForceMode2D.Impulse);
			}
	}

	void Uništipopotrebi ()
	{
		if (this.transform.position.y < 33f)
			Destroy (this.gameObject);
	}

	void Provjeridalinogedirajupod (out float cof)
	{
		if (bc.IsTouchingLayers (1 << LayerMask.NameToLayer ("Zid"))) {
			cof = 1f;
		}
		else
			cof = -0.1f;
	}

	// Use this for initialization
	void Start () {
	
	
		
		rb = GetComponent<Rigidbody2D> ();
		bc = GetComponent<BoxCollider2D> ();
		pc = GetComponent<PolygonCollider2D> ();
		cofzapeo = 1f;
		time = -1f;
		zastava = 65f;
		speed = 0.323f;
		killed = false;
		krvjačina = 0.05f;


	}

	void AnimirajKrv (Transform t)
	{
		GameObject[] Zrnakrvitemp = new GameObject[75];
		Krv[] Zrnakrvi = new Krv[75];
		for (int i = 0; i != Zrnakrvitemp.Length; i++) {
			Zrnakrvitemp [i] = (GameObject)Instantiate (Krvmodel, new Vector3 (t.position.x, t.position.y, -2.5f), new Quaternion (0, 0, 0, 0));
			Zrnakrvi [i] = Zrnakrvitemp [i].GetComponent<Krv> ();
		}
		for (int i = 0; i != Zrnakrvi.Length; i++) {
			Zrnakrvi [i].rb.AddForce (new Vector2 (Random.Range (-krvjačina, krvjačina), Random.Range (-krvjačina, krvjačina)) * 200f, ForceMode2D.Impulse);
		}
	}
	
	// Update is called once per frame

	void FixedUpdate () {

//	<>
		Uništipopotrebi ();
		if (!killed)
		{
		float cof;
		Promjenismjerpopotrebi (); 
		Provjeridalinogedirajupod (out cof);
		Pokrenise (cof);
			
		}




	}
	void OnCollisionEnter2D(Collision2D coll)
	{

		if (coll.gameObject.name == "Metak(Clone)")
		{

			rb.mass *= 2f;
			score.GetComponent<Score>().UpdateScore();


			Transform t = coll.gameObject.GetComponent<Transform>();
			


			Destroy (coll.gameObject);
			
			
			SpriteRenderer sr = GetComponent <SpriteRenderer>();
			sr.sprite = deadsprite;
			Destroy (bc);
			Destroy (pc);
			killed = true;


			AnimirajKrv (t);
			
				
	
		}
	}
}
