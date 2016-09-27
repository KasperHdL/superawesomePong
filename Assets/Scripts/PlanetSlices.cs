using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlanetSlices : MonoBehaviour {
	public int numPlayers;
	public List<RectTransform> slices;
	public List<Image> images;
	
	public Color[] colors;
	public KeyCode[] lefts;
	public KeyCode[] rights;
	
	public GameObject slicePrefab;
	public GameObject paddlePrefab;

	public ScoreDisplay display;


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
			paddle.angle = (lastAngle) * Mathf.PI * 2; 
			paddle.MinRad = (lastAngle - ratio/2) * Mathf.PI * 2;
			paddle.MaxRad = (lastAngle + ratio/2) * Mathf.PI * 2;

			paddle.left = lefts[i];
			paddle.right = rights[i];
			
			lastAngle = (float)1 / numPlayers + lastAngle;
		
		}
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
