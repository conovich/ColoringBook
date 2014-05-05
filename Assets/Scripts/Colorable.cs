using UnityEngine;
using System.Collections;

public class Colorable : MonoBehaviour {
	public GameObject SelectionIndicator;
	public Bucket MyBucket;
	public ColorLerper2D MyColorLerper;


	private Color currentColor;
	


	// Use this for initialization
	void Start () {
		InitCurrentColor();
		InitColorLerper();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//INIT FUNCTIONS//
	void InitCurrentColor(){
		SpriteRenderer myRenderer = gameObject.GetComponent<SpriteRenderer>();
		currentColor = myRenderer.color;
	}

	void InitColorLerper(){
		MyColorLerper = gameObject.GetComponent<ColorLerper2D>();
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
			if(Input.GetMouseButton(0)){
				MyBucket = collider.gameObject.GetComponent<Bucket>();
				if(MyBucket.MyColorBar.NumActive > 0){
					ChangeColor(MyBucket.MyColor);
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if(collider.gameObject.tag == "Bucket"){
			if(Input.GetMouseButton(0)){ //bucket not let go
				ChangeColor(currentColor);
			}
			else{ //mouse was let go
				SpriteRenderer myRenderer = gameObject.GetComponent<SpriteRenderer>();

				//currentColor = myRenderer.color;

				//if the currentColor isn't the temp color, change the currentColor, remove piece
				//otherwise, colorable was this color to begin with.
				if(currentColor != myRenderer.color){
					ColorObjectPermanently(myRenderer.color);
				}
			}
		}
	}

	public void ColorObjectPermanently(Color newColor){
		Debug.Log("Color object permanently.");
		MyBucket.MyColorBar.RemoveNextPieceColor();
		ChangeColor(newColor);
		currentColor = newColor;
	}

	void ChangeColor(Color newColor){
		if(newColor.a < 1.0f){
			newColor.a = 1.0f;
		}

		/*
		SpriteRenderer myRenderer = gameObject.GetComponent<SpriteRenderer>();
		myRenderer.color = newColor;
		*/

		MyColorLerper.SetTargetColor(newColor);
	}
}
