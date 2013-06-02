using UnityEngine;
using System.Collections;

public class UnbeatableAI : MonoBehaviour {

	bool upcolliding = false;
	bool downcolliding = false;
	
	
	// Update is called once per frame
	void Update () {
		Vector3 ballPosition = GameObject.Find("Ball").transform.position;
		Vector3 currentPosition = this.transform.position;
		if(ballPosition.z > currentPosition.z && downcolliding) {
			downcolliding = false;	
		}
		if(ballPosition.z < currentPosition.z && upcolliding) {
			upcolliding = false;	
		}
		
		if (!upcolliding && !downcolliding) {			
			Vector3 newPosition = new Vector3(currentPosition.x,currentPosition.y,ballPosition.z);
			this.transform.position = newPosition;
		}
	}
	
	void OnTriggerEnter(){
		upcolliding = true;
		downcolliding = true;
	}
}
