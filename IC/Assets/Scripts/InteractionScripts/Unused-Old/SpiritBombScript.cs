using UnityEngine;
using System.Collections;
using System;

public class SpiritBombScript : MonoBehaviour {

	public GameObject Foot_L;
	public GameObject Foot_R;
	public GameObject Hand_L;
	public GameObject Hand_R;
	public GameObject Head;
	public GameObject Spine;

	//iets verzinnen om die ground te vinden 
	private float HeadY;
	private float HandLeftY;
	private float HandRigthY;
	private float SpineY;
	private DateTime startDate;
	private bool startDateSet = false;
	private bool PoweringUp = false;

	public float SpiritBombX;
	public float SpiritBombY;
	public float SpiritBombZ;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		HeadY = Head.transform.position.y;
		HandLeftY = Hand_L.transform.position.y;
		HandRigthY = Hand_R.transform.position.y;
		SpineY = Spine.transform.position.y;
		SpiritBombX = 0;
		SpiritBombY = 0;
		SpiritBombZ = 0;

		if (HandLeftY > HeadY && HeadY < HandRigthY) {
			if(!startDateSet){
				startDateSet = true;
				startDate = DateTime.Now;
				Debug.Log(HandRigthY + "," + HandLeftY);
			}else if(startDate.AddSeconds(10) < DateTime.Now){
				//make particle bigger
				PoweringUp = true;
			}
			else if (startDate.AddSeconds(5) < DateTime.Now){
				//ramping time add particles
			}
		} else if (HandLeftY > HeadY) {
			//doen we hier iets?
		} else if (HandRigthY > HeadY) {
			//doen we hier iets?
		} else {
			startDateSet = false;
		}
		if(PoweringUp){
			ParticleEffectHelper.Instance.Explosion(Vector3.Lerp(Hand_L.transform.position, Hand_R.transform.position,0.5f));
			if(SpineY > HandLeftY && SpineY > HandRigthY){
				PoweringUp = false;
				Debug.Log ("Gooi SpiritBomb");
			}
		}
	}
}
