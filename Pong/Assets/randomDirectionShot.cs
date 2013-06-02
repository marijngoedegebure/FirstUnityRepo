using UnityEngine;
using System.Collections;

public class randomDirectionShot : MonoBehaviour {
	
	public int ballspeed;
	
	private bool ballspeedChanged =  false;
	private Vector3 collisionVector;
	
	private Vector3 startPosition;
	
	// Use this for initialization
	void Start () {
		startPosition = this.gameObject.transform.position;
		forceActivation();
	}
	
	private void resetBall() {
		ballspeed = 1000;
		this.gameObject.transform.position = startPosition;
		this.gameObject.rigidbody.velocity = Vector3.zero;
	}
	
	private void forceActivation() {
		int randomDirection = Random.Range (1,2);
		float yCoord= 13.646f;
		int randomZ = Random.Range (-52,30);
		float zCoord = (float)randomZ;
		
		float xCoord1 = 47.356f;
		float xCoord2 = -35.84f;
		
		if (randomDirection == 1) {
			Vector3 direction = new Vector3(xCoord1,yCoord,zCoord);
			direction.Normalize();
			rigidbody.AddForce(direction * ballspeed);
		}
		
		if (randomDirection == 2) {
			Vector3 direction = new Vector3(xCoord2,yCoord,zCoord);
			direction.Normalize();
			rigidbody.AddForce(direction * ballspeed);
		}
	}
	
	void Update() {
		if(ballspeedChanged) {
			
		}
	}
	
	void OnCollisionEnter(Collision theCollision){
		
		
		if(theCollision.gameObject.name == "Player" ||theCollision.gameObject.name == "Enemy" ) {
			ballspeedChanged = true;
			
			float difference = theCollision.gameObject.transform.position.z - this.transform.position.z;
			Vector3 direction = this.rigidbody.velocity;
			direction.Normalize();
			this.rigidbody.AddForce(direction * 200);
			ballspeed = ballspeed+200;
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name == "BorderBehindComputer" || other.gameObject.name == "BorderBehindPlayer") {
			resetBall();
			forceActivation();
		}
	}
			
}
