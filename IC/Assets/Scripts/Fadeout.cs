using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fadeout : MonoBehaviour {




	Image cas;
	RawImage rawImage;

	bool startScene;
	bool endScene;

	TimerExit timer;


	void Start(){
		startScene = true;
		endScene = false;
		timer = GameObject.FindWithTag("Alert").GetComponent<TimerExit>();
		rawImage = gameObject.GetComponentInChildren<RawImage> ();
		cas = gameObject.GetComponentInChildren<Image> ();
	}

	void Update()
	{
		if(timer.time < 5f){
			endScene = true;
		}
		if(startScene){
		cas.CrossFadeAlpha(0f, 2.0f, false);
			rawImage.CrossFadeAlpha(0f, 1.0f, false);
		}
		if (endScene) {
			startScene = false;
			cas.CrossFadeAlpha(1f, 2.0f, false);
			rawImage.CrossFadeAlpha(1f, 2.0f, false);
		}

	}
}
