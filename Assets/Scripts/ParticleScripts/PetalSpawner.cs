using UnityEngine;
using System.Collections;

public class PetalSpawner : ParticleSpawner {
	public Rigidbody2D Petal;
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
		Rigidbody2D petalParticle;
		petalParticle = GameObject.Instantiate(Petal, spawnPos, Quaternion.identity) as Rigidbody2D;

		Vector2 randomVel = Random.insideUnitCircle;
		if(randomVel.y > 0){
			randomVel.y = -randomVel.y;
		}
		petalParticle.AddForce(VelocityMult*(Random.insideUnitCircle));

		//randomize rotation
	}
}
