using UnityEngine;
using System.Collections;

public class randomDirectionShot : MonoBehaviour {
		
	
	public int ballspeed = 1000;
	
	private Vector3 startPosition;
	private int speedUpCounter;
	
	// Use this for initialization
	void Start () {
		speedUpCounter = 0;
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
			rigidbody.AddForce(Vector3.left * ballspeed);
		}
		
		if (randomDirection == 2) {
			Vector3 direction = new Vector3(xCoord2,yCoord,zCoord);
			direction.Normalize();
			rigidbody.AddForce(Vector3.left * ballspeed);
		}
	}
	
	void Update() {
		speedUpCounter++;
		if(speedUpCounter > 10 && ballspeed < 3000) {
			Vector3 direction = this.rigidbody.velocity;
			direction.Normalize();
			this.rigidbody.AddForce(direction * 100);
			ballspeed += 50;
			speedUpCounter = 0;
		}
	}
	
	void OnCollisionEnter(Collision other) {
		if(other.gameObject.name == "Player") {
			Vector3 padposition = other.transform.position;
			Vector3 ballposition = this.transform.position;
			float zdifference = ballposition.z - padposition.z;
			if(zdifference > 0) {
				Vector3 temp = new Vector3(0,0,zdifference*200);
				this.rigidbody.AddForce(temp);
			}
			else {
				Vector3 temp = new Vector3(0,0,zdifference*200);
				this.rigidbody.AddForce(temp);
			}
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.name == "BorderBehindComputer") {
				string formerScoreString = GameObject.Find("ScorePlayer").guiText.text;
				int formerScore = int.Parse (formerScoreString);
				formerScore++;
				GameObject.Find("ScorePlayer").guiText.text = formerScore.ToString();
				resetBall();
				forceActivation();
		}
		if ( other.gameObject.name == "BorderBehindPlayer") {
				string formerScoreString = GameObject.Find("ScoreEnemy").guiText.text;
				int formerScore = int.Parse (formerScoreString);
				formerScore++;
				GameObject.Find("ScoreEnemy").guiText.text = formerScore + "";
				resetBall();
				forceActivation();
		}
	}	
}
