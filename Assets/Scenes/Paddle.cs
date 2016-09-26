using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    float angle;
    float speed = 2;
	// Use this for initialization
	void Start () {
        angle = Mathf.Asin(transform.position.y / 2.66f);
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(KeyCode.A))
        {
            angle -= Time.deltaTime * 2;        
        }
        else if(Input.GetKey(KeyCode.D))
        {
            angle += Time.deltaTime * 2;
        }
        var x = Mathf.Cos(angle) * 2.66f;
        var y = Mathf.Sin(angle) * 2.66f;
        transform.position = new Vector3(x, y, 0);
        transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg + 90);
	}
}
