using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {
	
	public float speed = 100;
	public float maxSpeed = 10;
	
	public float jumpForce = 100;
	
	private bool jumping = false;
	private float timeBetweenJumps = 2f;
	private float timeSinceLastJump = 0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyUp (KeyCode.Space)) {
			jumping = false;
		}*/
		
		if(Input.GetKeyDown(KeyCode.Space) && jumping == false) {
				this.rigidbody.AddForce(jumpForce * Vector3.up);
				timeSinceLastJump = Time.time;
				jumping = true;
		}
		
		if(Time.time - timeSinceLastJump > timeBetweenJumps) {
			timeSinceLastJump = 0f;
			jumping = false;
		}
		
		if (Input.GetKey(KeyCode.LeftArrow)) {
			// face links en strave links
			if(-this.rigidbody.velocity.x < maxSpeed) {
				this.rigidbody.AddForce(speed * Vector3.left);
			}
			//this.rigidbody.AddForce(speed * Vector3.right);
		}
		
		if (Input.GetKey (KeyCode.RightArrow)) {
			// face rechts en strave rechts
			if(this.rigidbody.velocity.x < maxSpeed) {
				this.rigidbody.AddForce(speed * Vector3.right);
			}
		}
		
		if (Input.GetKeyDown (KeyCode.A)) {
			// Use first item
		}
		
		if (Input.GetKeyDown (KeyCode.S)) {
			// Use second item
		}
		
		if (Input.GetKeyDown (KeyCode.D)) {
			// Use third item	
		}
		
		if (Input.GetKeyDown (KeyCode.F)) {
			// Use fourth item	
		}
	}
	
	/*void OnCollisionEnter (Collider other) {
		if (other.gameObject.name == "Platform") {
			jumping = false;	
		}
	}*/
}
