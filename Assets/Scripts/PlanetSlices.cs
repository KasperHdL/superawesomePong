using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlanetSlices : MonoBehaviour {
	public int numPlayers;

	[HideInInspector]
	private List<RectTransform> slices;
	[HideInInspector]
	private List<Image> images;
	
	public Color[] colors;
	public KeyCode[] lefts;
	public KeyCode[] rights;
	
	public GameObject slicePrefab;
	public GameObject paddlePrefab;

	public GameObject ballPrefab;
	public ScoreDisplay display;
	public Gravity gravity;


	// Use this for initialization
	void Awake () {
		slices = new List<RectTransform>(numPlayers);
		images = new List<Image>(numPlayers);

		display.numPlayers = numPlayers;

		float lastAngle = 0;
		float ratio = (float) 1 / numPlayers;
		
		for(int i = 0; i < numPlayers ; i++){
			GameObject player = Instantiate(paddlePrefab, Vector3.zero, Quaternion.identity) as GameObject;
			
			GameObject g = Instantiate(slicePrefab, Vector3.zero, Quaternion.identity) as GameObject;
			g.transform.SetParent(transform, false);
			slices.Add(g.transform as RectTransform);
			images.Add(g.GetComponent<Image>());

			images[i].color = colors[i];
			images[i].fillAmount = (float)1 / numPlayers;
			slices[i].Rotate(0,0,lastAngle * 360);

			Paddle paddle = player.GetComponent<Paddle>();
			float angle = ratio * (numPlayers - 2) * (Mathf.PI/2)  - i * ratio * Mathf.PI * 2;

			paddle.angle = -angle; 
			paddle.MinRad = -angle - ratio * Mathf.PI;
			paddle.MaxRad = -angle + ratio * Mathf.PI;

			paddle.left = lefts[i];
			paddle.right = rights[i];
			
			lastAngle = (float)1 / numPlayers + lastAngle;
		
		}

		int randomStart = Random.Range(0,numPlayers);
		GameObject b = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity) as GameObject;

		float ballAngle = ratio * (numPlayers - 2) * (Mathf.PI/2) - randomStart * ratio * Mathf.PI * 2;
		
        var x = Mathf.Cos(ballAngle) * 7f;
        var y = Mathf.Sin(ballAngle) * 7f;
		
        b.transform.position = new Vector3(x, y, 0);
		gravity.bodies.Add(b.GetComponent<Rigidbody2D>());
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
