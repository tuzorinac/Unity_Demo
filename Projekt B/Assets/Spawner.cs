using UnityEngine;
using System.Collections;
using System.Threading;

public class Spawner : MonoBehaviour {

	// Use this for initialization
	public GameObject e;
	public float time;
	public GameObject score;
	public Sprite deadsprite;
	public float xrangemin;
	public float yrangemin;
	public float xrangemax;
	public float yrangemax;
	public float spawntime;
	void Start () {

		time = -1f;

	}
	
	// Update is called once per frame
	void Update () {
			

		if (time == -1f)
			time = Time.timeSinceLevelLoad;
		else if (time + spawntime < Time.timeSinceLevelLoad)
		{
			time = -1f;
			float x;
			float y;
	
			GameObject o = (GameObject)Instantiate (e,new Vector3 (Random.Range(xrangemin,xrangemax),Random.Range(yrangemin,yrangemax),5), new Quaternion(0,0,0,0));
			Enemyv2 newenemy = o.GetComponent <Enemyv2>();
			newenemy.score = score;
			newenemy.deadsprite = deadsprite;
		
		}
			
	
	}

}
