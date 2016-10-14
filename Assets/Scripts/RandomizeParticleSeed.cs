using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class RandomizeParticleSeed : MonoBehaviour {
	//pour personnaliser les particules
	void Awake(){
		//GetComponent<ParticleSystem> ().randomSeed = 0; // ...
	}

}
