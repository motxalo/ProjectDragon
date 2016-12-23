using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {

	public bool  pulseActive 	= false;

	public float amplitudeV 	= 0.01f; 
	public float speedV	    	= 5f;
	public float amplitudeH 	= 0f; 
	public float speedH	    	= 0f;

	private Vector3 tempPos;
	// Use this for initialization
	void Start () {
		tempPos = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if ( pulseActive ) {
			tempPos.y = tempPos.y + Random.Range(0,amplitudeV)*Mathf.Sin(speedV*Time.time);
			tempPos.x = tempPos.x + Random.Range(0,amplitudeH)*Mathf.Sin(speedH*Time.time);
			transform.localPosition = tempPos;
		}
	}

}
