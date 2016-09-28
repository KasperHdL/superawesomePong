using UnityEngine;
using System.Collections;

public class Esclator : MonoBehaviour {

	public Gravity gravity;

	private float startTime;
	public float delay;
	public float max;
	public float ballcoef;
	public float gravcoef;

	private Rigidbody2D body;

	void Start () {
		startTime = Time.time;
		body = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate() {
		if(Time.time > startTime + delay){
			float a = Time.time - (startTime + delay);
			if(a > max)a = 0;
		
			body.AddForce(body.velocity * ballcoef * a);
			gravity.gravityCoef_distSqr += gravcoef * a;
			
		}
		
	
	}
}
