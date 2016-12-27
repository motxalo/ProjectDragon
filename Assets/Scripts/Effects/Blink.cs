using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {

	public GameObject eyesUp;
	public GameObject eyesDown;

	private Vector3 startPosUp;
	private Vector3 startPosDown;
	private Vector3 endPosUp;
	private Vector3 endPosDown;
	// Use this for initialization
	void Start () {
		startPosUp 		= eyesUp.transform.position;
		startPosDown 	= eyesDown.transform.position;
		endPosUp 		= startPosUp 	+ new Vector3(0f,800f,0f);
		endPosDown 		= startPosDown 	- new Vector3(0f,800f,0f);
		BlinkEyes();
	}

	public bool doOpen = false;
	public bool doClose = false;
	public bool doBlink = false;

	void Update(){
		if (doOpen){
			doOpen = false;
			OpenEyes();
		}

		if (doClose){
			doClose = false;
			CloseEyes();
		}

		if (doBlink){
			doBlink = false;
			BlinkEyes();
		}
	}

	public void OpenEyes(){
		LeanTween.move(eyesUp,endPosUp,1f).setEase(LeanTweenType.easeInSine);
		LeanTween.move(eyesDown,endPosDown,1f).setEase(LeanTweenType.easeInSine);
	}

	public void CloseEyes(){
		LeanTween.move(eyesUp,startPosUp,1f).setEase(LeanTweenType.easeInSine);
		LeanTween.move(eyesDown,startPosDown,1f).setEase(LeanTweenType.easeInSine);
	}

	public void BlinkEyes(){
		LeanTween.move(eyesUp,endPosUp,5f).setEase(LeanTweenType.easeInElastic);
		LeanTween.move(eyesDown,endPosDown,5f).setEase(LeanTweenType.easeInElastic);
	}
}
