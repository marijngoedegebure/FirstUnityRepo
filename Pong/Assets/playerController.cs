using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	
	public int speed;
	public bool upcolliding = false;
	public bool downcolliding = false;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey ("up") && upcolliding == false) {
			transform.Translate (0,0, (Time.deltaTime * speed));
			downcolliding = false;
		}
		
		if (Input.GetKey ("up") && upcolliding == true) {
			downcolliding = false;	
		}
		
		if (Input.GetKey ("down") && downcolliding == false) {
			transform.Translate (0,0,(-Time.deltaTime * speed));
			upcolliding = false;
		}
		
		if (Input.GetKey("down") && downcolliding == true) {
			upcolliding = false;
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(other.name == "BorderBottomPlayerWall" || other.name == "BorderTopPlayerWall") {
			upcolliding = true;
			downcolliding = true;
		}
	}
}
