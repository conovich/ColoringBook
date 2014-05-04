using UnityEngine;
using System.Collections;

//particles already won't collide with other particles due to collision layer settings.
//particles already won't collide with colorables due to collision layer settings.

public class ParticleCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		Die();
	}

	void Die(){
		Destroy(gameObject);
	}
}
