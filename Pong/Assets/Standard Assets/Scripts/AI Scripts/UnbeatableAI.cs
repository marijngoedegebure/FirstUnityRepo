using UnityEngine;
using System.Collections;

public class UnbeatableAI : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		Vector3 ballPosition = GameObject.Find("Ball").transform.position;
		Vector3 currentPosition = this.transform.position;
		Vector3 newPosition = new Vector3(currentPosition.x,currentPosition.y,ballPosition.z);
		this.transform.position = newPosition;
	}
}
