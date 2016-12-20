using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplacementPoint : MonoBehaviour {
	public bool startActive = false;
	public LeanTweenType movemntType = LeanTweenType.easeInOutBounce;
	public float movementTime = 2f;
	public bool keepY = true;

	public GameObject[] linkedPoints;
	// Use this for initialization
	void Start () {
		if(!startActive){
			Deactivate();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public float DoMovement(Transform _player){
		Vector3 destiny = transform.position;
		if ( keepY ) destiny.y=_player.position.y;
		LeanTween.move(_player.gameObject, destiny, movementTime ).setEase(movemntType);
		Deactivate();
		int i = 0;
		for (i = 0; i < linkedPoints.Length; i++){
				linkedPoints[i].SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
		}
		
		return movementTime;
	}

	public void Activate(){
		GetComponent<Renderer>().enabled = true;
		GetComponent<Collider>().enabled = true;
	}
		

	public void Deactivate(){
		GetComponent<Collider>().enabled = false;
		GetComponent<Renderer>().enabled = false;
	}


	public void KillKids(string _name){
		int i = 0;
		for (i = 0; i < linkedPoints.Length; i++){
			if(gameObject.name != _name)
				linkedPoints[i].SendMessage("Deactivate", SendMessageOptions.DontRequireReceiver);
		}
	}
}
