using UnityEngine;
using System.Collections;

public class LeafSpawner : ParticleSpawner {
	public Rigidbody2D Leaf;
	public float VelocityMult;
	
	private int randomCountdownToFall = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CountDown();
	}

	override public void CountDown(){
		if(randomCountdownToFall <= 0){
			EmitParticles();
			randomCountdownToFall = Random.Range(1, 20);
		}
		randomCountdownToFall--;
	}

	override public void EmitParticles(){
		Vector2 spawnPos = transform.position;
		Rigidbody2D leafParticle;
		leafParticle = GameObject.Instantiate(Leaf, spawnPos, Quaternion.identity) as Rigidbody2D;
		
		leafParticle.AddForce(VelocityMult*(Random.insideUnitCircle));

		//randomize rotation
	}
}
