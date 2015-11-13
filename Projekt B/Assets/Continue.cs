using UnityEngine;
using System.Collections;

public class Continue : MonoBehaviour {

	// Use this for initialization
	float sec;
	float time;
	void Start () {
	

		sec = 5f;
		time = Time.timeSinceLevelLoad;

	}
	
	// Update is called once per frame
	void Update () {
	

		if (time < Time.timeSinceLevelLoad -1f)
		 {
			
			sec--;
			time = Time.timeSinceLevelLoad;
	}
			

		TextMesh tm = GetComponent <TextMesh> ();

		tm.text = "CONTINUE IN " + sec;

		if (sec == 0f)
			Application.LoadLevel("v2.1.2");
			



	}

}
