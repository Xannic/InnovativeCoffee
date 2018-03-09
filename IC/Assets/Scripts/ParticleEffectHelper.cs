using UnityEngine;
using System.Collections;

public class ParticleEffectHelper : MonoBehaviour {

	public static ParticleEffectHelper Instance;

	public ParticleSystem particleEffect;

	// Use this for initialization
	void Awake () {
		if(Instance != null){

		}
		Instance = this;
	}

	public void Explosion(Vector3 position){
		instantiate (particleEffect, position);
	}

	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position){
		ParticleSystem newParticleSystem = Instantiate (prefab, position, Quaternion.identity) as ParticleSystem;
		Destroy (newParticleSystem.gameObject,newParticleSystem.startLifetime);
		return newParticleSystem;
	}
}
