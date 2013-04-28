#pragma strict

function Update () {
	var horiz : float = Input.GetAxis("Horizontal");
	
	Debug.Log(horiz);
	
	transform.Translate(Vector3(horiz, 0, 0));
}