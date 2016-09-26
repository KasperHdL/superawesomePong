using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public float angle;
    public float speed = 2;

    public KeyCode right;
    public KeyCode left;

    public float MaxRad;
    public float MinRad;
    


	// Update is called once per frame
	void Update () {
	    if(Input.GetKey(right))
        {
            angle -= Time.deltaTime * 2;
        }
        else if(Input.GetKey(left))
        {
            angle += Time.deltaTime * 2;
        }
        if(angle < MinRad)
            angle = MinRad;
        if(angle > MaxRad)
            angle = MaxRad;
        
        var x = Mathf.Cos(angle) * 2.66f;
        var y = Mathf.Sin(angle) * 2.66f;
        transform.position = new Vector3(x, y, 0);
        transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg + 90);
	}
}
