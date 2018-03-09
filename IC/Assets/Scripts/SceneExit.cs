using UnityEngine;
using System.Collections;

public class SceneExit : MonoBehaviour {

	public string url = "http://www.xannic.nl/api/coffee/played.php";

	IEnumerator  Start (){
		
		WWW www = new WWW(url);
		yield return www;
		
	}

	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.tag == "Hands")
		{
			Start ();
			Application.LoadLevel ("MainScreen");
		}
	}
}
