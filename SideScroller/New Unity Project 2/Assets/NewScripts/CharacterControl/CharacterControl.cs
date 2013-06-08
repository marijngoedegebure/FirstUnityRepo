using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {
	/*
	 * Script to describe the possibilities of the player
	 * Keyboard control functions are implemented
	 * 
	 */
	
	
	public float speed = 100;
	public float maxSpeed = 10;
	
	public float jumpForce = 100;
	
	public GameObject camera;
	
	private bool jumping = false;
	public bool allowedToMoveRight = true;
	public bool allowedToMoveLeft = true;
	
	public float timeBetweenJumps = 2.4f;
	private float timeSinceLastJump = 0f;
	
	public GameObject meleeattack;
	public GameObject platform;
	
	public GameObject inventory;
	
	private bool facingLeft = false;
	private bool facingRight = true;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKeyUp (KeyCode.Space)) {
			jumping = false;
		}*/
		checkMovement();
		
		if(Input.GetKeyDown(KeyCode.Space) && jumping == false) {
				this.rigidbody.AddForce(jumpForce * Vector3.up);
				timeSinceLastJump = Time.time;
				jumping = true;
		}
		
		if(Time.time - timeSinceLastJump > timeBetweenJumps) {
			timeSinceLastJump = 0f;
			jumping = false;
		}
		
		if (Input.GetKey(KeyCode.LeftArrow) && allowedToMoveLeft) {
			// face links en strave links
			if(-this.rigidbody.velocity.x < maxSpeed) {
				this.rigidbody.AddForce(speed * Vector3.left);
				if(facingRight) {
					this.transform.Rotate(new Vector3(0,180,0));
					facingRight = false;
					facingLeft = true;
				}
			}
		}
		
		if (Input.GetKey (KeyCode.RightArrow) && allowedToMoveRight) {
			// face rechts en strave rechts
			if(this.rigidbody.velocity.x < maxSpeed) {
				this.rigidbody.AddForce(speed * Vector3.right);
				if(facingLeft) {
					this.transform.Rotate(new Vector3(0,-180,0));
					facingRight = true;
					facingLeft = false;
				}
			}
		}
		
		if (Input.GetKeyDown (KeyCode.A)) {
			// Cycle through melee weapons
			//inventory.nextMeleeWeapon();
		}
		
		if (Input.GetKeyDown (KeyCode.S)) {
			// Cycle through ranged weapons
			//inventory.nextRangedWeapon();
		}
		
		// Possibilities:
		// Bow, wand, ninja star
		if (Input.GetKeyDown (KeyCode.D)) {
			// Use ranged weapon
			
		}
		
		
		/*
		 * Possibilities
		 * Fire sword, frost sword, water sword
		 * 
		 */
		if (Input.GetKeyDown (KeyCode.F)) {
			// Use Melee weapon item
			// For now spawn on player
			Vector3 spheredetector = Vector3.zero;
			if(facingLeft) {
				spheredetector = new Vector3(transform.position.x-1,transform.position.y,transform.position.z);
			}
			else {
				spheredetector = new Vector3(transform.position.x+1,transform.position.y,transform.position.z);
			}
			Collider[] colliders = Physics.OverlapSphere(spheredetector,0.5f);
			
			for(int i = 0;i < colliders.Length;i++) {
				if(colliders[i].name == "Platform") {
					PlatformScript script = (PlatformScript) colliders[i].gameObject.GetComponent(typeof(PlatformScript));
					if(script.isDestroyable) {
						Destroy(colliders[i].gameObject);
					}
				}
			}
		}
	}
	
	private void checkMovement() {
		// Check if your allowed to move left/right (so you cannot jump against walls and stay there
		Vector3 sphereLocForward = Vector3.zero;
		if(facingLeft) {
			sphereLocForward = new Vector3(transform.position.x-0.5f,transform.position.y,transform.position.z);
		}
		if(facingRight) {
			sphereLocForward = new Vector3(transform.position.x+0.5f,transform.position.y,transform.position.z);
		}
		check (sphereLocForward);
	}
	
	private void check(Vector3 sphereLoc) {
		Collider[] colliders = Physics.OverlapSphere(sphereLoc,0.2f);
		bool didSomething = false;
		for(int i = 0;i < colliders.Length;i++) {
			if(colliders[i].name == "Platform") {
				if(facingRight) {
					allowedToMoveRight = false;
					allowedToMoveLeft = true;
				}
				if(facingLeft) {
					allowedToMoveRight = true;
					allowedToMoveLeft = false;
				}
				didSomething = true;
			}
		}
		if( !didSomething) {
			allowedToMoveRight = true;
			allowedToMoveLeft = true;
		}
	}
	
	void OnCollisionEnter (Collision other) {
		if(other.transform.position.y < transform.position.y) {
			jumping = false;
			timeSinceLastJump = 0f;
		}
	}
}
