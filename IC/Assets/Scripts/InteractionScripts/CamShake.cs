using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour 
{
	

	Transform camTransform;
	public GameObject cam;

	public float shake = 0f;

	public float shakeAmount = 5f;
	public float decreaseFactor = 1.0f;
	
	Vector3 originalPos;
	
	void Awake()
	{
		camTransform = gameObject.transform;
	}
	
	void OnEnable()
	{
		originalPos = camTransform.localPosition;
	}
	
	void Update()
	{
		if (shake > 0)
		{
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
			shake -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shake = 0f;
			camTransform.localPosition = originalPos;
		}
	}
	
}