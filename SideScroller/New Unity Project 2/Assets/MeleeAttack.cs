using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {
	/*
	 * Class used to detect collision with other objects
	 * This object will be created as soon as a button is pressed
	 * TODO: Detect collision with another object
	 * Ideas:
	 * - OnTriggerEnter
	 * - OnCollisionEnter (this object has a box collider of size common to the weapon)
	 * - Raycasting
	 */
	
	
	public float duration = 2.0f;
	
	private float creationTime;
		
	// Use this for initialization
	void Start () {
		creationTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float currentTime = Time.time;
		if(currentTime - creationTime > 2.0f) {
			Destroy(gameObject);	
		}
	}
}
