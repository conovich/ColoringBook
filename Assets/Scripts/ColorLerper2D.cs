using UnityEngine;
using System.Collections;

public class ColorLerper2D : MonoBehaviour {
	public bool shouldLerp = true;
	SpriteRenderer myRenderer;
	Color targetColor;

	// Use this for initialization
	void Start () {
		myRenderer = gameObject.GetComponent<SpriteRenderer>();
		SetTargetColor(myRenderer.color);
	}
	
	// Update is called once per frame
	void Update () {
		if(shouldLerp){
			LerpColor();
		}
	}

	public void SetTargetColor(Color newColor){
		targetColor = newColor;
		if(targetColor.a < 1.0f){
			targetColor.a = 1.0f;
		}
	}

	void LerpColor(){
		Color oldColor = myRenderer.color;
		myRenderer.color = Color.Lerp(oldColor, targetColor, 3.0f*Time.deltaTime);
	}
}
