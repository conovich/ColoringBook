using UnityEngine;
using System.Collections;

public class Bucket : MonoBehaviour {
	public Sprite[] ColorBarPieces;
	public Color MyColor;

	private ParticleSystem[] myParticleSystems;

	public int particleCount;

	// Use this for initialization
	void Start () {
		myParticleSystems = (ParticleSystem[])GameObject.FindObjectsOfType<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	private ParticleSystem.Particle[] particles = new ParticleSystem.Particle[1000];
	
	void LateUpdate() {
		for(int i = 0; i < myParticleSystems.Length; i++){
			int particlesLength = myParticleSystems[i].GetParticles(particles);

			//if valid particles to enter the bucket...
			if(myParticleSystems[i].tag == gameObject.tag){
				for (int j = 0; j < particlesLength; j++){
					//if a particle is super close to the bucket... I DONT KNOW WHY THE DISTANCES ARE WEIRDDDDDD. BLARG. STOPPED DEBUGGING HERE.
					if(gameObject.tag == "Blue"){
						Debug.Log (((Vector2)particles[j].position - (Vector2)transform.position).magnitude);
					}
					if((particles[j].position - transform.position).magnitude < 4.0f){
						particles[j].lifetime = -1.0f;
						particleCount++;
					}
				}
			}
			//if not valid particles to enter the bucket...
			else{
				for (int j = 0; j < particlesLength; j++){
					//if a particle is super close to the bucket...
					if((particles[j].position - transform.position).magnitude < 0.02){
						particles[j].velocity = -particles[j].velocity;
					}
				}
			}

			/*int length = particleSystem.GetParticles(particles);
			int i = 0;
			
			while (i < length) {
				
				if(particles[i].color = Color.red;
				   i++;
				
			}
			
			particleSystem.SetParticles(particles, length); }*/
		}
	
}
	
	
}
