using UnityEngine;
using System.Collections;

public class OrbitDetector : MonoBehaviour {

	private float lastHitTime = 0;
	public float maxOrbitDuration;
	public float orbitStopperCoef;
	public float orbitAdderCoef;
	
	private Rigidbody2D body;

	void Start () {
		body = GetComponent<Rigidbody2D>();
		lastHitTime = Time.time;
	
	}
	
	void Update () {
		float l = Time.time - lastHitTime;
		if(l > maxOrbitDuration){
			body.AddForce(-body.velocity * (l - maxOrbitDuration) * orbitStopperCoef);
			
			
		}
		
	
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(Time.time - lastHitTime > maxOrbitDuration){
			body.AddForce(body.velocity * ((Time.time - lastHitTime) - maxOrbitDuration) * orbitAdderCoef);

			
		}
		lastHitTime = Time.time;
	}
}
