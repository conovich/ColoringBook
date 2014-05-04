using UnityEngine;
using System.Collections;

public class SunshineSpawner : ParticleSpawner {
	public GameObject SunShine;
	
	private int randomCountdownToSun = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CountDown();
	}

	override public void CountDown(){
		if(randomCountdownToSun <= 0){
			EmitParticles();
			randomCountdownToSun = Random.Range(1, 20);
		}
		randomCountdownToSun--;
	}
	
	override public void EmitParticles(){
		Vector2 spawnPos = transform.position;
		GameObject.Instantiate(SunShine, spawnPos, Quaternion.identity);
		//add in velocity here!
	}
}
