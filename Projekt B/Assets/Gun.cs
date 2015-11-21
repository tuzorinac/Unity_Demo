using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {


	bool IsLeft;
	Transform p,p1,k,k1;
	public KeyCode Lijevo;
	public KeyCode Desno;
	public GameObject metak;
	public GameObject audiometak;
	public AudioSource audiosrc;
	public KeyCode pucanj;
	float time;

	// Use this for initialization
	void Start () {
		IsLeft = true;

		Transform[] tempdjeca= GetComponentsInChildren<Transform>();
		
		
		foreach (Transform t in tempdjeca)
		{
			// Početakpucnja (1) KrajPucnja (1)
		
			if (t.name ==  "Početakpucnja")
				p = t;
			
			else if (t.name ==  "Početakpucnja (1)")
				p1 = t;
			else if (t.name ==  "KrajPucnja (1)")
				k1 = t;
			else if (t.name ==  "KrajPucnja")
				k = t;

		}

		//	print (p1.name);
	}

	void Pucanj() {

	

		if (time > Time.timeSinceLevelLoad - 0.9f)
			return;


		audiosrc.Play ();

		Vector3 pucanj1 = p.position - k.position;
		Vector3 pucanj2 = p1.position - k1.position;

		GameObject metak1 = (GameObject) Instantiate (metak, k.position, new Quaternion (0, 0, 0, 0));
		GameObject metak2 = (GameObject)Instantiate (metak, k1.position , new Quaternion (0, 0, 0, 0));
		
		Rigidbody2D rb1 = metak1.GetComponent<Rigidbody2D> ();
		Rigidbody2D rb2 = metak2.GetComponent<Rigidbody2D> ();


		rb1.AddForce (-pucanj1 * 30f);
		rb2.AddForce (-pucanj2 * 30f);

 
	
	
		time = Time.timeSinceLevelLoad;






	}
	// Update is called once per frame
	void Update () {

		float zrotacija = transform.localRotation.z;
		zrotacija *= 180f;
		if (zrotacija < 0)
			zrotacija += 360f;
		

		if (IsLeft  &&  zrotacija  > 90 && zrotacija  < 270)
		{
			Vector3 theScale = transform.localScale;
			theScale.y *= -1;
			transform.localScale = theScale;
			IsLeft = false;
			
			
		}	
		else if (!IsLeft  &&  (zrotacija <=  90 || zrotacija  >= 270))
		{
			Vector3 theScale = transform.localScale;
			theScale.y *= -1;
			transform.localScale = theScale;
			IsLeft = true;
			
			
			
		}


		if (Input.GetKey(Lijevo))
		    {
					
			this.transform.Rotate(new Vector3(0,0,-1) * 2f);
				
			    
			 }
		else if (Input.GetKey(Desno))
		{
			
			this.transform.Rotate(new Vector3(0,0,1)* 2f);
			
			
			
		}
		if (Input.GetKey (pucanj))
			Pucanj ();
	





	}
}
