using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {
	public Rigidbody2D[] bodies;
	public float gravityCoef;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0;i < bodies.Length;i++){
			bodies[i].AddForce(gravityCoef * (transform.position - bodies[i].transform.position));
		}
	}
}
