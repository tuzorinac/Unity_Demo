using UnityEngine;
using System.Collections;

public class Metak : MonoBehaviour {


	float timeout;
	public float cofx;
	public float cofy;
	Rigidbody2D rb;
	bool init;
	// Use this for initialization
	void Start () {
		timeout = Time.timeSinceLevelLoad;
		rb = GetComponent<Rigidbody2D> ();
		init = true;

	}
	
	// Update is called once per frame
	void FixedUpdate () {


		if (init && (rb.velocity.x != 0f ||rb.velocity.y!=0f))
		{
		cofx = rb.velocity.x;
		cofy = rb.velocity.y;
			init= false;
	}
			
		if (timeout < Time.timeSinceLevelLoad - 2.5f)
			Destroy (this.gameObject);
			
	}
}
