using UnityEngine;
using System.Collections;

public class RainSpawner : ParticleSpawner {
	public GameObject RainDrop;
	public float Width;

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
		float random = Random.Range(0.0f, Width);
		Vector2 spawnPos = new Vector2(transform.position.x + random, transform.position.y);
		GameObject.Instantiate(RainDrop, spawnPos, Quaternion.identity);
	}

}
