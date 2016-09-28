using UnityEngine;
using System.Collections;

public class BallScorer : MonoBehaviour {

	public int indexOfLastPlayer = -1;
	private SpriteRenderer sprite;
	
	private TrailRenderer trail;
	void Start(){
		sprite = GetComponent<SpriteRenderer>();
		trail = GetComponent<TrailRenderer>();
	}
	void OnCollisionEnter2D(Collision2D coll){
		if(coll.gameObject.tag == "Paddle"){
			Paddle p = coll.gameObject.GetComponent<Paddle>();
			if(p == null)
				p = coll.transform.parent.GetComponent<Paddle>();
			indexOfLastPlayer = p.index;
			sprite.color = p.color;
			trail.material.SetColor("_Color", p.color);
		}
	}
}
