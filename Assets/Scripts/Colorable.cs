using UnityEngine;
using System.Collections;

public class Colorable : MonoBehaviour {
	public GameObject SelectionIndicator;

	private Color currentColor;
	


	// Use this for initialization
	void Start () {
		InitCurrentColor();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//INIT FUNCTIONS//
	void InitCurrentColor(){
		SpriteRenderer myRenderer = gameObject.GetComponent<SpriteRenderer>();
		currentColor = myRenderer.color;
	}


	//TOGGLE FUNCTIONS
	public void ToggleSelector(bool isSelected){
		if(!SelectionIndicator.renderer.enabled){
			SelectionIndicator.renderer.enabled = true;
		}
		else{
			SelectionIndicator.renderer.enabled = false;
		}
	}

	void OnMouseDown(){
		Selector.Instance.SelectColorable(gameObject);
	}


	//COLLISION FUNCTIONS
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag == "Bucket"){
			Bucket myBucket = collider.gameObject.GetComponent<Bucket>();
			ChangeColor(myBucket.MyColor);
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if(collider.gameObject.tag == "Bucket"){
			Bucket myBucket = collider.gameObject.GetComponent<Bucket>();
			ChangeColor(currentColor);
		}
	}

	void ChangeColor(Color newColor){
		if(newColor.a < 1.0f){
			newColor.a = 1.0f;
		}
		SpriteRenderer myRenderer = gameObject.GetComponent<SpriteRenderer>();
		myRenderer.color = newColor;
	}
}
