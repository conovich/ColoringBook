using UnityEngine;
using System.Collections;

public class GlobalParticleSystems : MonoBehaviour {
	private ParticleSpawner[] myParticleSystems;
	public int currentCountdown;


	// Use this for initialization
	void Start () {
		Init (); 
	}

	void Init(){
		myParticleSystems = GameObject.FindObjectsOfType<ParticleSpawner>();
		Debug.Log(myParticleSystems.Length);
		ResetRandomCountdown();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentCountdown <= 0){
			TurnOnRandomSystem();
			TurnOffRandomSystem();
			ResetRandomCountdown();
		}
		CountDown();
	}

	void CountDown(){
		currentCountdown--;
	}

	void ResetRandomCountdown(){
		currentCountdown = (int)Random.Range(4*Time.deltaTime, 10*Time.deltaTime);
	}
	
	void TurnOnRandomSystem(){
		int randomIndex = Random.Range(0, myParticleSystems.Length);
		myParticleSystems[randomIndex].TurnOn();
		//Debug.Log ("ON" + randomIndex);
	}

	void TurnOffRandomSystem(){
		int randomIndex = Random.Range(0, myParticleSystems.Length);
		myParticleSystems[randomIndex].TurnOff();
		Debug.Log ("OFF" + randomIndex);
	}

}
