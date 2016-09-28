using UnityEngine;
using System.Collections;

public class Scorer : MonoBehaviour {

	
	public enum ScoreMethod{
		OnHit,
		EveryoneElseOnHit,
		LastPlayer
	}
	public ScoreMethod method;
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
				
			if(method == ScoreMethod.OnHit){
				display.scores[i]++;
			}else if(method == ScoreMethod.EveryoneElseOnHit){
				for (int j = 0; j < display.numPlayers; j++)
				{
					if(i == j)continue;
					display.scores[j]++;
					
				}
			}
			
		}
	}
}
