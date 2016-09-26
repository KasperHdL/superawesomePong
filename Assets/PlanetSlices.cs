using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlanetSlices : MonoBehaviour {
	public List<RectTransform> slices;
	public List<Image> images;
	
	public GameObject slicePrefab;

	public int numPlayers;

	// Use this for initialization
	void Start () {
		slices = new List<RectTransform>(numPlayers);
		images = new List<Image>(numPlayers);


		float lastAngle = 0;
		
		for(int i = 0; i < numPlayers ; i++){
			
			GameObject g = Instantiate(slicePrefab, Vector3.zero, Quaternion.identity) as GameObject;
			g.transform.SetParent(transform, false);
			slices.Add(g.transform as RectTransform);
			images.Add(g.GetComponent<Image>());

			images[i].fillAmount = (float)1 / numPlayers;
			slices[i].Rotate(0,0,lastAngle * 360);
			
			lastAngle = (float)1 / numPlayers + lastAngle;
		
		}
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
