using UnityEngine;
using System.Collections;

public class Enemyv2 : MonoBehaviour {
	public static float zastava;
	Rigidbody2D rb;
	BoxCollider2D bc;
	float cofzapeo;
	float timecofdrugismer;
	bool pada = true;
	static float speed;
	PolygonCollider2D pc;
	public GameObject score;
	bool killed;
	public Sprite deadsprite;
	public GameObject Krvmodel;
	float duljinavektoraizlaznekrvi;
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
		zastava = 86.3f;
	
		speed = 0.323f;
		killed = false;
		duljinavektoraizlaznekrvi = 0.0005f;

	}

	void AnimirajKrv (Transform t, Vector2 vlcty)
	{
		GameObject[] Zrnakrvitemp = new GameObject[50];
		Krv[] Zrnakrvi = new Krv[50];



		//print (xv + " " + yv);

		for (int i = 0; i != Zrnakrvitemp.Length; i++) {
			Zrnakrvitemp [i] = (GameObject)Instantiate (Krvmodel, new Vector3 (t.position.x, t.position.y, -2.5f), new Quaternion (0, 0, 0, 0));
			Zrnakrvi [i] = Zrnakrvitemp [i].GetComponent<Krv> ();
		}

		float xmin, xmax, ymin, ymax, cofx, cofy;


		cofx = 1f;
		cofy = 1f;

		print (vlcty.x + " vlcty stari " + vlcty.y);


		vlcty *= (1 - duljinavektoraizlaznekrvi/vlcty.magnitude);


		print (vlcty.x + " vlcty novi " + vlcty.y);
		

		xmin = vlcty.x - 20f;
		xmax = vlcty.x + 20f;

		ymin = vlcty.y - 20f;
		ymax = vlcty.y + 20f;


		print (xmin + " " + xmax + "xmas");


		/* Nova verzija

		float hunit, wunit;
		hunit = GetComponent<RectTransform>().rect.height / 6f;
		wunit = GetComponent<RectTransform>().rect.width / 6f;
		

	





		for (float i=3;i!=0;i--)
		{

			float xveći = this.transform.position.x - wunit * i;
			float xmanji = this.transform.position.x - wunit * (i -1);
			print("x kolizije: " + t.position.x + "xveći" + xveći 
			 + "xmanji " +  xmanji);


			if (xveći <= t.position.x && xmanji > t.position.x)
				{
				xmin = krvjačina / (i + 1);
				xmax = krvjačina * i;

				if (xv < 0f)
					cofx = -1f;
				else cofx = 1f;

				break;
					
				}
			else if (xveći >= t.position.x && xmanji < t.position.x)
			{
				xmin = krvjačina *i;
				xmax = krvjačina / (i+1);

				if (0f < xv)
					cofx = -1f;
				else cofx = 1f;

				break;
				
			}
			else 
			{
				cofx = 1f;
				xmin = krvjačina - 0.1f;
				xmax = krvjačina + 0.1f;


			}
				
			} */
			

	
	 
	  // Stara verzija
	  
	
	/*  if (t.transform.position.x < this.transform.position.x + GetComponent<RectTransform>().rect.width/5
	    &&  t.transform.position.x > this.transform.position.x-GetComponent<RectTransform>().rect.width/5)
		{
			xmin = -krvjačina/2;
			xmax = krvjačina/2;

			cofx = 1f;

		}
			
		else if (this.transform.position.x > t.position.x){
			xmin = -krvjačina;
			xmax = 0f;

			if (xv < 0f)
				cofx = 1f;
			else cofx = -1f;


		}
		else 
		{
			xmin = 0f;
			xmax = krvjačina;
			if (0f < xv)
				cofx = 1f;
			else cofx = -1f;
		}	*/

	/*	if (t.transform.position.y < this.transform.position.y + GetComponent<RectTransform>().rect.height/6
		    &&  t.transform.position.y > this.transform.position.y-GetComponent<RectTransform>().rect.height/6)
		{

			ymin = -krvjačina/2;
			ymax = krvjačina/2;

			cofy = 1f;
		}
		else if (this.transform.position.y > t.position.y)
		{
			ymin = -krvjačina;
			ymax = 0f;
			if (yv < 0f)
				cofy = 1f;
			else cofy = -1f;
		}
		else 
		{
			ymin = 0f;
			ymax = krvjačina;
			if (0f < yv)
				cofy = 1f;
			else cofy = -1f;
		}	


		print ("cofx: "+cofx); */


		if (float.IsNaN (xmin) || float.IsNaN (xmax)) {

			xmin = -20f;
			xmax = 20f;

		}
		if (float.IsNaN (ymin) || float.IsNaN (ymax)) {
			
			ymin = -20f;
			ymax = 20f;
			
		}
		    

		for (int i = 0; i != Zrnakrvi.Length; i++) {
			Zrnakrvi [i].rb.AddForce (new Vector2 (Random.Range (xmin, xmax) *cofx, Random.Range (ymin, ymax)*cofy) * 0.1f, ForceMode2D.Impulse);
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

			
			float xv =  coll.gameObject.GetComponent<Metak>().cofx;
			float yv = coll.gameObject.GetComponent<Metak>().cofy;

			rb.mass *= 2f;
			score.GetComponent<Score>().UpdateScore();


			Transform t = coll.gameObject.GetComponent<Transform>();
			


			Destroy (coll.gameObject);


		
			SpriteRenderer sr = GetComponent <SpriteRenderer>();
			sr.sprite = deadsprite;
			Destroy (bc);
			Destroy (pc);
			killed = true;


			AnimirajKrv (t, new Vector2(xv,yv));
			
				
	
		}
	}
}
