using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public int index;
    public Color color;

    public float angle;
    public float speed = 2;

    public KeyCode right;
    public KeyCode left;

    public float MaxRad;
    public float MinRad;
    
    public SpriteRenderer ellipse;
    public bool useKeyboard;

    Vector2 midNormal;

    void Start(){
        midNormal = Vector3.Cross(new Vector2(Mathf.Cos(angle), Mathf.Sin(-angle)), Vector3.forward);
    }
	// Update is called once per frame
	void Update () {
        if(useKeyboard){
            
            if(Input.GetKey(right))
            {
                angle -= Time.deltaTime * speed;
            }
            else if(Input.GetKey(left))
            {
                angle += Time.deltaTime * speed;
            }
        }else{

            float h,v;
            h = Input.GetAxis("Horizontal_" + index);
            v = Input.GetAxis("Vertical_" + index);
            
            Vector2 dir = new Vector2(h, v);
//            if(dir.magnitude < 0.2f) dir = Vector2.zero;
            dir = dir.normalized;

   //         Debug.Log("dir: " + dir + " midN: " + midNormal);

            float projected = Vector2.Dot(dir, midNormal);
//            Debug.Log(projected);
            if(projected != 0)
                projected = Mathf.Sign(projected);
 //           Debug.Log(projected);
  //          Debug.Log("");

            angle += projected * speed * Time.deltaTime;
        }

       if(angle < MinRad)
            angle = MinRad;
        if(angle > MaxRad)
            angle = MaxRad;
 

        var x = Mathf.Cos(angle) * 2.66f;
        var y = Mathf.Sin(angle) * 2.66f;
        transform.position = new Vector3(x, y, 0);
        transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg - 90);
	}
}
