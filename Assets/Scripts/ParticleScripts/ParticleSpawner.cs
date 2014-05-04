using UnityEngine;
using System.Collections;

public abstract class ParticleSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public abstract void CountDown();

	public abstract void EmitParticles();
}
