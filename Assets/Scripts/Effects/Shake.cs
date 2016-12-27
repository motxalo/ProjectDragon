using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {


	public bool doShake = false;
	public float amplitudeV = 2f;
	public float amplitudeH = 2f;

	public float shakeTime = 1f;
	private float actShakeTime = 0f;
	private Vector3 startingPos;

	private int shakes = 2;

	// Use this for initialization
	void Start () {
		startingPos = transform.localPosition;	
	}
	
	// Update is called once per frame
	void Update () {
		if(doShake)
			ShakeIt();	
	}

	void ShakeIt(){
		float tsin = Mathf.Sin(Mathf.PI * actShakeTime  );
		transform.localPosition = startingPos +  new Vector3( amplitudeH * tsin , amplitudeV * tsin , 0f);
		actShakeTime += Time.deltaTime / shakeTime;
		if ( actShakeTime > 1f){
			shakes--;
			actShakeTime = 0f;
			if( shakes <= 0 ){
				transform.localPosition = Vector3.zero;
				doShake = false;
			}
		}
	}

	public void ShakeCamera(Vector2 amplitude, float time, int _shakes){
		amplitudeH = amplitude.x;
		amplitudeV = amplitude.y;
		shakeTime = time;
		shakes = _shakes;
		doShake = true;
	}
		
	public void ShakeCamera(){
		amplitudeH = .2f;
		amplitudeV = .2f;
		shakeTime = .2f;
		shakes = 2;
		doShake = true;
	}
}
