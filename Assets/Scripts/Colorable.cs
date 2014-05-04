using UnityEngine;
using System.Collections;

public class Colorable : MonoBehaviour {
	public GameObject SelectionIndicator;

	private Color currentColor;
	private Bucket myBucket;
	


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
			if(Input.GetMouseButton(0)){
				myBucket = collider.gameObject.GetComponent<Bucket>();
				if(myBucket.MyColorBar.NumActive > 0){
					ChangeColor(myBucket.MyColor);
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

				//if the currentColor isn't the temp color, change the currentColor, remove piece
				//otherwise, colorable was this color to begin with.
				if(currentColor != myRenderer.color){
					myBucket.MyColorBar.RemoveNextPieceColor();
					currentColor = myRenderer.color;
				}
			}
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
