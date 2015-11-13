using UnityEngine;
using System.Collections;

public class Zastava : MonoBehaviour {

	// Use this for initialization

	float t = -1f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if (t!=-1f && t < Time.timeSinceLevelLoad -3f)
		    {
			Application.LoadLevel("gameover");
	
		}
	}
	void OnCollisionEnter2D(Collision2D coll)
	{

		if (t != -1f)
			return;

		else if (coll.gameObject.name == "Enemymodel(Clone)")
		{


			t =  Time.timeSinceLevelLoad;

			SpriteRenderer sr = GetComponent<SpriteRenderer>();
			sr.color = 	(Color)new Color32 (24,255,74,255);


			Score s = GetComponentInChildren<Score>();
			s.gameover = true;



		}
	}
}
