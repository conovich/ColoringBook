using UnityEngine;
using System.Collections;

public class ParticleCollision : MonoBehaviour {
	public string ParentName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.name != ParentName && collision.gameObject.name != gameObject.name){
			Debug.Log(collision.gameObject.name);
			Die();
		}
	}

	void Die(){
		Destroy(gameObject);
	}
}
