using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GestureManager : MonoBehaviour {
	
	public GameObject[] bodyparts = new GameObject[11];
	private Windows.Kinect.JointType[] _jointType = new Windows.Kinect.JointType[11];
	public GameObject water;
	public GameObject BlowingLeaves;
	public bool activatedWind = false;
	public  bool blowingWind = false;
	public GameObject Wind;
	public GameObject sun;
	public float sunRotateSpeed;
	private bool _controllable = false;
	//TODO moet private worden public voor debug
	public HandsState _current;
	public FootState _foot;
	public bool sunrise;

	private float Distance;
	public string tempState;
	public float Timer = 0f;
	EllipsoidParticleEmitter[] leaveCollection;
	WindZone windzone;
	public TrackingState track;
	RotateBehaviour waterRotate;

	//Variables for the Swipe action
	bool KeepTimeSwipe = false;
	float TempSwipeX = 0;
	float SwipeDistance;
	bool backSwiped = false;
	bool sunRiseEnd = false;

	void Start(){
		_current = HandsState.HandsDown;
		track = TrackingState.NoTracking;
		windzone = Wind.GetComponent<WindZone>();
		waterRotate = water.GetComponent<RotateBehaviour>();
		windzone.radius = 5;
		leaveCollection = BlowingLeaves.GetComponentsInChildren<EllipsoidParticleEmitter>();
		sunrise = false;
		InstantiateJoints ();
		InstantiateBodyParts ();
	}

	private void InstantiateJoints(){
		_jointType [0] = Windows.Kinect.JointType.Head;
		_jointType [1] = Windows.Kinect.JointType.HandRight;
		_jointType [2] = Windows.Kinect.JointType.HandLeft;
		_jointType [3] = Windows.Kinect.JointType.ElbowRight;
		_jointType [4] = Windows.Kinect.JointType.ElbowLeft;
		_jointType [5] = Windows.Kinect.JointType.FootLeft;
		_jointType [6] = Windows.Kinect.JointType.FootRight;
		_jointType [7] = Windows.Kinect.JointType.KneeLeft;
		_jointType [8] = Windows.Kinect.JointType.KneeRight;
		_jointType [9] = Windows.Kinect.JointType.FootLeft;
		_jointType [10] = Windows.Kinect.JointType.FootRight;

	}

	private void InstantiateBodyParts(){
		for(var y = 0; y < bodyparts.Length;y++){
			var d = bodyparts[y].GetComponent<JointPosition>();
			d._jointType = _jointType[y];
			bodyparts[y] = Instantiate (bodyparts[y]);
		}
	}


	//TODO make private when done
	//TODO refactor this with a cool name, not handstatos
	public enum HandsState{
		HandsDown,HandsUp,
		LeftHandForward,RightHandForward,
		LeftHandRaised,RightHandRaised
	}

	//TODO make private when done with debugging
	public void ControlHandsStates()
	{
			switch(_current){
			case HandsState.HandsDown:

			blowingWind = false;
				break;
			case HandsState.HandsUp:
			sunrise = true;
			blowingWind = true;
				break;
			case HandsState.LeftHandForward:
				break;
			case HandsState.LeftHandRaised:
			swipe (bodyparts[4],bodyparts[2],-3);
				break;
			case HandsState.RightHandForward:
				break;
			case HandsState.RightHandRaised:

				//bodyparts[1] = righthand // bodyparts[3] = ellowbowright
				swipe (bodyparts[1],bodyparts[3],3);
				break;
			}
		//-rotateSpeed
	}

	private void swipe(GameObject SwipeActor, GameObject SwipeAnchor,float rotate){
		float SwipeActorX = SwipeActor.transform.position.x;
		float SwipeAnchorX = SwipeAnchor.transform.position.x;
		sunRotateSpeed = rotate;
		
		if (SwipeActorX > SwipeAnchorX) {
			if(backSwiped){
				Timer = 2f;
				backSwiped = false;
			}
		}else if(SwipeActorX < SwipeAnchorX){
			backSwiped = true;
		}
	}

	void DayNight (float rotateSpeed){
		sun.transform.rotation = Quaternion.Euler (sun.transform.rotation.x-rotateSpeed,sun.transform.rotation.y,0)* sun.transform.rotation;

	}


	void Sun(float rotateSpeed){
		sun.transform.rotation = Quaternion.Euler (0,sun.transform.rotation.y-rotateSpeed,0)* sun.transform.rotation;
	}

	public enum TrackingState{
		Tracking,NoTracking
	}

	public enum FootState{
		RightFootForward, LeftFootForward,
		RightKick, LeftKick,
		DefaultFoot, LeftFootRaised
	}

	public void ControlFootStates(){
			switch(_foot){
				case FootState.DefaultFoot:
					break;
				case FootState.LeftFootForward:
					break;
				case FootState.RightFootForward:
					break;
				case FootState.LeftFootRaised:
					break;

			}

	}

	public int totalspin;
	void WindAndLeaves(){
		if(sunrise){
			if(!sunRiseEnd){
			sun.transform.rotation = Quaternion.Euler (sun.transform.rotation.x-2,0,0)* sun.transform.rotation;
			totalspin +=2;
			if(totalspin > 70){
				sunrise = false;
					sunRiseEnd = true;
				}
			}
		}
		if (blowingWind) {
			if (!activatedWind) {
				foreach (var t in leaveCollection) {
					t.emit = true;
					activatedWind = true;
				}
			}
			waterRotate.RotationAmount = new Vector3(0,5,0);
			windzone.radius = 5;
		} else {
			foreach (var t in leaveCollection) {
				t.emit = false;
			}
			windzone.radius = 0;
			waterRotate.RotationAmount = new Vector3(0,1,0);
			activatedWind = false;
		}
	}



	void Update () {
		//Sun ();
		if(Timer >= 0){
			Timer -= Time.deltaTime;
			Sun(sunRotateSpeed);
		}


		WindAndLeaves ();

			if (bodyparts [2].transform.position.y > bodyparts [0].transform.position.y && bodyparts [0].transform.position.y < bodyparts [1].transform.position.y) {
				_current = HandsState.HandsUp;
			} else if (bodyparts [2].transform.position.y > bodyparts [0].transform.position.y) {
				_current = HandsState.LeftHandRaised;
			} else if (bodyparts [1].transform.position.y > bodyparts [0].transform.position.y) {
				_current = HandsState.RightHandRaised;

			} else if (bodyparts [1].transform.position.z > bodyparts [2].transform.position.z) {
				_current = HandsState.RightHandForward;

			} else if (bodyparts [2].transform.position.z > bodyparts [1].transform.position.z) {
				_current = HandsState.LeftHandForward;
			} //bodyparts[5] = leftFoot bodyparts[6] = rightFoot
		//bodyparts[7] = kneeLeft bodyparts[8] = rightKnee 
		else {
				_current = HandsState.HandsDown;
			}
			if (bodyparts [5].transform.position.y >= (bodyparts [8].transform.position.y - Distance)) {
				_foot = FootState.LeftFootRaised;

			} else {
				_foot = FootState.DefaultFoot;
			}

		ControlHandsStates ();
	}
}
