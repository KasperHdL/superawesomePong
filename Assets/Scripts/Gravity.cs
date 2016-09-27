using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	public Rigidbody2D[] bodies;
	public float gravityCoef_oneOverDistSqr;
	public float gravityCoef_distSqr;
	public float gravityCoef_dist;

	public CalcMethod calculationMethod;

	public enum CalcMethod{
		oneOverDistanceSquared,
		distanceSquared,
		distance,
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		for(int i = 0;i < bodies.Length;i++){
			Vector3 delta =(transform.position - bodies[i].transform.position);
			switch(calculationMethod){
				case CalcMethod.oneOverDistanceSquared:
					bodies[i].AddForce((gravityCoef_oneOverDistSqr / Vector3.Dot(delta,delta)) * delta.normalized);
				break;
				case CalcMethod.distanceSquared:
					bodies[i].AddForce((gravityCoef_distSqr * Vector3.Dot(delta, delta)) * delta.normalized);
				break;
				case CalcMethod.distance:
					bodies[i].AddForce(gravityCoef_dist * delta);

				break;
			}
		}
	}
}
