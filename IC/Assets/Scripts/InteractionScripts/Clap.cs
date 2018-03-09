using UnityEngine;
using System.Collections;

public class Clap : MonoBehaviour {
	private GameObject RightHand;
	private GameObject LeftHand;
	public float fuckjouoda;
	public float rechts;
	public float links;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(RightHand.transform.position,LeftHand.transform.position)<0.01){
			rechts = RightHand.transform.position.x;
			links = LeftHand.transform.position.x;
		}
		fuckjouoda = Vector3.Distance(RightHand.transform.position,LeftHand.transform.position);

	}

	public void setRightHand(GameObject RightHand){
		this.RightHand = RightHand;
	}

	public void setLeftHand(GameObject LeftHand){
		this.LeftHand = LeftHand;
	}

}
