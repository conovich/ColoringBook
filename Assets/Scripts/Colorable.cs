using UnityEngine;
using System.Collections;

public class Colorable : MonoBehaviour {
	public GameObject SelectionIndicator;
	


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

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

	void OnCollisionEnter2D(){
		
	}
}
