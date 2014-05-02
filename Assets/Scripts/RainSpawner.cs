using UnityEngine;
using System.Collections;

public class RainSpawner : MonoBehaviour {
	public GameObject RainDrop;
	public float Width;

	private int randomCountdownToRain = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(randomCountdownToRain <= 0){
			Rain();
			randomCountdownToRain = Random.Range(1, 20);
		}
		randomCountdownToRain--;

	}

	void Rain(){
		float random = Random.Range(0.0f, Width);
		Vector2 spawnPos = new Vector2(transform.position.x + random, transform.position.y);
		GameObject.Instantiate(RainDrop, spawnPos, Quaternion.identity);
	}

}
