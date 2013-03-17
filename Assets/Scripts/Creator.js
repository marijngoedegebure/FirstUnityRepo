#pragma strict

var thePreFab : GameObject;

function Start () {
	
	var instance : GameObject = Instantiate(thePreFab, transform.position, transform.rotation);
	
}