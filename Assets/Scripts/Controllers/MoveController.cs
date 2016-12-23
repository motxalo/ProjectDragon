using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

	private float distance = 100f;
	private bool canRaycast = true;

	public Transform aim;

	public Pulse camPulse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(canRaycast) DoRayCast();
	}

	private DisplacementPoint  lastDestPoint;

	void DoRayCast(){
		
		RaycastHit  hit; 

		if (Physics.Raycast(transform.position, Camera.main.transform.forward,out hit, distance)){
			aim.position = hit.point;
			if ( hit.collider.gameObject.tag == "DisplacementPoint" ){
				if(lastDestPoint){
					lastDestPoint.KillKids(hit.collider.name);
				}
				lastDestPoint = hit.collider.GetComponent<DisplacementPoint>();
				Debug.Log(hit.collider.name);
				float dispTime  = lastDestPoint.DoMovement(transform);
				canRaycast = false;
				camPulse.pulseActive = true;
				aim.GetComponent<Renderer>().enabled = false;
				Invoke("ActivateRaycast", dispTime );
			}
		}
		else{
			aim.position = transform.position + Camera.main.transform.forward*distance;
		}
	}

	void ActivateRaycast(){
		camPulse.pulseActive = false;
		aim.GetComponent<Renderer>().enabled = true;
		canRaycast = true;
	}
}
