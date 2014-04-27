using UnityEngine;
using System.Collections;

public class ClickDragSnap : MonoBehaviour 
{
	public LayerMask raycastLayer;
	
	public bool isDragged = false;
	public bool isSelected = false;
	Vector2 mouseOffset;

	Vector2 origPos;

	bool shouldSnapBack = false;

	private BucketSelector bucketSelector;
	
	// Use this for initialization
	void Start () {
		origPos = transform.position;
		bucketSelector = GameObject.FindGameObjectWithTag("BucketSelector").GetComponent<BucketSelector>();
	}
	
	// Update is called once per frame
	void Update () {
		if(isDragged){
			Vector2 targetWorldPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseOffset;
			transform.position = targetWorldPos;
		}
		if(isSelected){
			bucketSelector.SelectedBucket = gameObject;
		}  

		if(shouldSnapBack){
			SnapBackToOrig();
		}
	}

	void OnMouseDown(){
		if(bucketSelector.SelectedBucket == null){
			isSelected = true;
			mouseOffset = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
			Debug.Log("mouse pos: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
			Debug.Log(transform.position);

		}
		else{
			Deselect();
		}
	}

	void OnMouseOver(){
		if(Input.GetMouseButton(0) && isSelected){
			isDragged = true;
		}
		else{
			Deselect();
		}
	}

	void OnMouseUp(){
		Deselect();
	}

	void Deselect(){
		isSelected = false;
		isDragged = false;
		bucketSelector.SelectedBucket = null;

		shouldSnapBack = true;
	}

	void SnapBackToOrig(){
		if((Vector2)transform.position != origPos){
			transform.position = Vector2.Lerp(transform.position, origPos, 0.04f); 
		}
		else{
			shouldSnapBack = false;
		}
	}
}

