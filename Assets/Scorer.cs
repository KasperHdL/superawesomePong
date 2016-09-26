using UnityEngine;
using System.Collections;

public class Scorer : MonoBehaviour {

	public ScoreDisplay display;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Ball"){
			float a = Vector3.Angle(Vector3.down, coll.transform.position - transform.position);
			if(coll.transform.position.x > transform.position.x)
				a = (180 - a) + 180;
			
			int i = (int)(a / ((float)1 / display.numPlayers * 360));
			display.scores[i]++;
			
		}
	}
}
