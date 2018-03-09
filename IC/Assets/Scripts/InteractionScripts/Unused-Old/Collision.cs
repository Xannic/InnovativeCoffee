using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

	bool move;
	float speed = 0.02f;
	float step;

	Vector3 startLocation;

	void Start () {
		 step = 0.02f;
		move = false;
		startLocation = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (move) {
			this.transform.position = new Vector3 (transform.position.x, transform.position.y + speed, transform.position.z);
		} else {

			transform.position = Vector3.MoveTowards(transform.position, startLocation, step);
		}

	}

	void OnTriggerStay (Collider other) 
	{
		if (other.gameObject.tag == "Hands")
		{
			move = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Hands")
		{
			move = false;
		}
	}
}
