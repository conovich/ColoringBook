using UnityEngine;
using System.Collections;

public class SunshineSpawner : ParticleSpawner {
	public Rigidbody2D SunShine;
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
		Rigidbody2D sunShineParticle;
		sunShineParticle = GameObject.Instantiate(SunShine, spawnPos, Quaternion.identity) as Rigidbody2D;

		sunShineParticle.AddForce(VelocityMult*(Random.insideUnitCircle));
	}

	override public void TurnOn(){
		isOn = true;
	}
	
	override public void TurnOff(){
		isOn = false;
	}
}
