using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

	public bool controlActive = true;

	public bool enableMouse 	= true;
	public bool enableKeyboard 	= false;
	public bool enableGyros 	= false;

	private Vector3 tempRotation;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!controlActive) return;
		tempRotation = Vector3.zero;
		if(enableMouse) UpdateMouse();
		if(enableGyros) UpdateGyro();
		if(enableKeyboard) UpdateKeyboard();
		DoRotate();
	}

	Vector3 oldMousePos = new Vector3(-1f,-1f,-1f);
	public float mouseSensibility = 1f;
	public bool invertMouseY	  = true;

	void UpdateMouse(){
		if(oldMousePos.x < 0f )
		{
			oldMousePos = Input.mousePosition;
			return;
		}
		Vector3 deltarot 	= Input.mousePosition - oldMousePos;
		oldMousePos 		= Input.mousePosition;
		int mouseY = 1;
		if (invertMouseY) mouseY = -1;
	    tempRotation = transform.rotation.eulerAngles + mouseSensibility * new Vector3(deltarot.y*mouseY, deltarot.x, 0f );
	}

	void UpdateGyro(){}

	void UpdateKeyboard(){

		int mouseY = 1;
		if (invertMouseY) mouseY = -1;
		Vector3 keyboardInput = Vector3.zero;
		if (Input.GetKey(KeyCode.UpArrow))   keyboardInput += Vector3.left*mouseY;
		if (Input.GetKey(KeyCode.DownArrow)) keyboardInput -= Vector3.left*mouseY;
		if (Input.GetKey(KeyCode.LeftArrow)) keyboardInput -= Vector3.up;
		if (Input.GetKey(KeyCode.RightArrow))keyboardInput += Vector3.up;
		tempRotation = transform.rotation.eulerAngles + mouseSensibility * keyboardInput;
	}

	void DoRotate(){
		if (tempRotation == Vector3.zero) return;
		if (tempRotation.x > 90 && tempRotation.x < 180) tempRotation.x = 89;
		if (tempRotation.x >180 && tempRotation.x < 270) tempRotation.x = 270; 
		//tempRotation.x = Mathf.Clamp(tempRotation.x, -89, 89 );
		transform.rotation = Quaternion.Euler( tempRotation );
	}
}
