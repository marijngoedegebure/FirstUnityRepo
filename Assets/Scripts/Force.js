#pragma strict

var power : float = 500.0;

function Start () {
	rigidbody.AddForce(Vector3(0,0,power));
}