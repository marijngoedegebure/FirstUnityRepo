using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	void OnTriggerEnter( Collider myTrigger) {
		if(myTrigger.gameObject.name == "Cube") {
			Debug.Log ("Box went through");	
		}
	}
}
