using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
/*
 * Script used to make the camera smoothly follow the player
 * Possibility to implement a smooth following camera
 * A camera that detects when its not in sync with the player and will then adjust it's position
 * in multiple steps
 * For now it is just a basic following camera
 */
	Vector3 formerPlayerPosition;
	
	void Start () {
		formerPlayerPosition = GameObject.Find("Player").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPlayerPosition = GameObject.Find ("Player").transform.position;
		Vector3 difference = currentPlayerPosition - formerPlayerPosition;
		Vector3 newPosition = this.transform.position + difference;
		transform.position = newPosition;
		formerPlayerPosition = currentPlayerPosition;
	}
}
