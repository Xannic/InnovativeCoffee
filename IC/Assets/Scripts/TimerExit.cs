using UnityEngine;
using System;
using System.Collections;


public class TimerExit : MonoBehaviour {
	public int exitTime;
	private string url = "http://www.xannic.nl/api/coffee/played.php";

	public DateTime StartDateTime;
	public DateTime StartFadeTime;
	public float speed;
	public float time = 30f;
	RectTransform rect;
	// Use this for initialization
	void Start () {
		rect = gameObject.GetComponent<RectTransform>();
		StartDateTime = DateTime.Now;
	}


	IEnumerator Next (){
		
		WWW www = new WWW(url);
		yield return www;
		
		//OrderFill (www.text);
		
	}
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		Debug.Log (time);

		if (time < 10) {
			if (rect.anchoredPosition3D.y > -230) {
				rect.anchoredPosition3D = new Vector3 (rect.anchoredPosition3D.x,
		                                      rect.anchoredPosition3D.y - (speed * Time.deltaTime),
		                                      rect.anchoredPosition3D.z);
			}
			if (time < 0) {
				//WWW www = new WWW(url);
				StartCoroutine (Next ());
				Application.LoadLevel ("MainScreen");

			}
		}

	}
}
