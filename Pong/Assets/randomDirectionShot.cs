using UnityEngine;
using System.Collections;

public class randomDirectionShot : MonoBehaviour {
	
	public int ballspeed;
	
	// Use this for initialization
	void Start () {
		int randomDirection = Random.Range (1,2);
		
		if (randomDirection == 1) {
			rigidbody.AddForce(Vector3.left * ballspeed);	
		}
		
		if (randomDirection == 2) {
			rigidbody.AddForce(Vector3.left	* ballspeed);
		}
		
	}
}
