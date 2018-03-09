using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class JointPosition : MonoBehaviour 
{
    public Windows.Kinect.JointType _jointType;
    public GameObject _bodySourceManager;

	public int X_force =2;
	public int Y_force =2;
	public int Z_force =2;

	public GameObject target;
    private BodySourceManager _bodyManager;

	// Use this for initialization
	void Start () 
    {
		target = GameObject.FindWithTag ("Target");
		_bodySourceManager = GameObject.FindWithTag ("BodyManager");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (_bodySourceManager == null)
        {
            return;
        }

        _bodyManager = _bodySourceManager.GetComponent<BodySourceManager>();
        if (_bodyManager == null)
        {
            return;
        }

        Body[] data = _bodyManager.GetData();
        if (data == null)
        {
            return;
        }

        // get the first tracked body...
        foreach (var body in data)
        {
            if (body == null)
            {
                continue;
            }

            if (body.IsTracked)
            {
				Debug.Log("Tracking");
               //this.gameObject.transform.position = new Vector3
               // this.gameObject.transform.localPosition =  body.Joints[_jointType].Position;
                var pos = body.Joints[_jointType].Position;
				this.gameObject.transform.position = new Vector3((pos.X*X_force)+target.transform.position.x, 
				                                                 (pos.Y*Y_force)+target.transform.position.y, 
				                                                 (-pos.Z*Z_force)+target.transform.position.z);

                break;
            }
        }
	}
}
