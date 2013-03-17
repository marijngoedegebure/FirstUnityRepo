#pragma strict

function Start () {

}

function Update () {
	if(Input.GetButtonDown("Jump"))
	{
		transform.position.z += 1.0;
	}
}