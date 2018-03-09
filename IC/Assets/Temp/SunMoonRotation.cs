using UnityEngine;
using System.Collections;

public class SunMoonRotation : MonoBehaviour {

	public Renderer water;

	
	void Update () 
	{
		Vector3 tvec = Camera.main.transform.position;
		water.material.mainTextureOffset = new Vector2(Time.time / 100, 0);
		water.material.SetTextureOffset("_DetailAlbedoMap", new Vector2(0, Time.time / 80));
	}
}
