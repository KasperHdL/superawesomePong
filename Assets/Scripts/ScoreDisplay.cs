using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {
	[HideInInspector]
	public List<Text> scoreTexts;
	
	[HideInInspector]
	public List<int> scores;
	public GameObject scorePrefab;
	public Transform planet;
	
	[HideInInspector]
	public int numPlayers;
	public float offset = 35;
	// Use this for initialization
	void Start () {
		scoreTexts = new List<Text>(numPlayers);
		scores = new List<int>(numPlayers);
		
		float lastAngle = 0;
		float ratio = (float) 1 / numPlayers;
		for(int i = 0; i < numPlayers; i++){
			GameObject g = Instantiate(scorePrefab, Vector3.zero, Quaternion.identity) as GameObject;

			g.transform.SetParent(transform,false);
			scoreTexts.Add(g.GetComponent<Text>());
			scores.Add(0);
			
			float angle = ratio * ((numPlayers - 2) * (Mathf.PI/2))  - i * ratio * Mathf.PI * 2;
			g.transform.localPosition = new Vector3(-Mathf.Cos(angle) * offset, -Mathf.Sin(angle) * offset,0);

			lastAngle = (float) 1 / numPlayers + lastAngle;
		
		}
	}

	void Update(){
		for(int i = 0; i < scores.Count; i++){
			scoreTexts[i].text = "" + scores[i];
		}
		
	}
}
