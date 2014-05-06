using UnityEngine;
using System.Collections;

public class LeafSpawner : ParticleSpawner {
	public Rigidbody2D Leaf;
	public float VelocityMult;
	
	private int randomCountdownToFall = 0;
	private bool isOn = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isOn){
			CountDown();
		}
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
		leafParticle.AddTorque(Random.Range(0.0f, 50.0f));
	}

	override public void TurnOn(){
		isOn = true;
	}
	
	override public void TurnOff(){
		isOn = false;
	}
}
