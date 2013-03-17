#pragma strict
function OnCollisionEnter(theCollision : Collision){
	
	if(theCollision.gameObject.name == "Floor"){
		Debug.Log("Hit the floor");
	}
	else if(theCollision.gameObject.name == "Wall"){
		Debug.Log("Hit the wall");
	}
}