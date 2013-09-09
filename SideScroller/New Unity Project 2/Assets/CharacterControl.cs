using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {
	/*
	 * Script to describe the possibilities of the player
	 * Keyboard control functions are implemented
	 * 
	 */
	
	
	public float walkSpeed = 1000f;
	public float maxVelocity = 100f;
	
	// Variables used for jumping logic
	public float jumpForce = 1000f;
	private float jumpRepeatTime = 1.5f;
	
	// Variables used for movement
	private Vector3 movement = Vector3.zero;
	private float currentVerticalSpeed = 0.0f;
	private float currentMovSpeed = 0.0f;
	
	// Variables used for jumping
	private CollisionFlags lastCollision;
	private bool grounded = true;
	private bool jumping = false;
	
	// Last time the jump button was clicked down
	private float lastJumpButtonTime = -10.0f;
	// Last time we performed a jump
	private float lastJumpTime = -1.0f;
	// Jump timout
	private float jumpTimeout = 1.0f;
	
	
	private Vector3 inAirVelocity = Vector3.zero;

	private float lastGroundedTime = 0.0f;


	private bool isControllable = true;
	
	public GameObject camera;
	
	
	public GameObject meleeattack;
	public GameObject platform;
	
	public Inventory inventory;
	
	private bool facingLeft = false;
	private bool facingRight = true;
	
	public State state;
	
	// Use this for initialization
	void Start () {
		inventory = (Inventory)GetComponent(typeof(Inventory));
	}
	
	// Update is called once per frame
	/*
	 * Revamp of jumping, jumping will now be measured by velocity.
	 * Holding down the button longer will have no effect, you will need to release and press again
	 * to jump
	 */
	
	void Update() {
		grounded = IsGrounded ();
		
		Vector3 forward = this.transform.forward;
		forward.y = 0.0f;
		forward.z = 0.0f;
		forward = Vector3.Normalize(forward);
		
		if(Input.GetKeyDown(KeyCode.Space)) {
			ApplyJumping ();
		}
		
		// Still needs to use collisionflags
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
			if(!(this.rigidbody.velocity.x < maxVelocity)) {
				if(facingLeft) {
					this.rigidbody.AddForce(new Vector3(-walkSpeed,0,0));
				}
				else {
					facingRight = false;
					facingLeft = true;
					this.transform.Rotate(new Vector3(0,180,0),Space.World);
					this.rigidbody.AddForce(new Vector3(-walkSpeed,0,0));
				}
			}
		}
		
		// Still needs to use collisionflags
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			if(!(this.rigidbody.velocity.x < maxVelocity)) {
				if(facingRight) {
					this.rigidbody.AddForce(new Vector3(walkSpeed,0,0));
				}
				else {
					facingRight = true;
					facingLeft = false;
					this.transform.Rotate(new Vector3(0,180,0),Space.World);
					this.rigidbody.AddForce(new Vector3(walkSpeed,0,0));
				}
			}
		}
		
		// Handling of the other input keys
		
		if (Input.GetKeyDown (KeyCode.A)) {
			// Cycle through melee weapons
			inventory.nextMeleeWeapon();
		}
		
		if (Input.GetKeyDown (KeyCode.S)) {
			// Cycle through ranged weapons
			inventory.nextRangedWeapon();
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
		
		
		// Need to update the collisions so they are properly handled
		// there is a code sample bookmarked in chrome for this
		
	}
	
	void ApplyJumping() {
		// Prevent jumping too fast after each other
		if (lastJumpTime + jumpRepeatTime > Time.time)
			return;

		if (IsGrounded()) {
			// Jump
			// - Only when pressing the button down
			// - With a timeout so you can press the button slightly before landing		
			if (Time.time < lastJumpButtonTime + jumpTimeout) {
				//verticalSpeed = CalculateJumpVerticalSpeed (jumpHeight);
				this.rigidbody.AddForce(new Vector3(0,jumpForce,0));
				SendMessage("DidJump", SendMessageOptions.DontRequireReceiver);
			}
		}
	}
	
	// Will not be neccesary because of the use of a rigidbody
	void ApplyGravity() {
		
	}
	
	
	bool IsGrounded() {
		return true;
	}

	
	void OnCollisionEnter (Collision other) {
	
	}
}
