using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	// Use this for initialization
	public int score;
	public bool gameover;
	void Start () {
	
		score = 0;
		gameover = false;
	}


	public void UpdateScore()
	{
		if (gameover)
			return;


		score += 10;
		TextMesh tm = GetComponent <TextMesh> ();
		tm.text = "Score:" + score;



	}
		
	// Update is called once per frame
	void Update () {
	
	}
}
