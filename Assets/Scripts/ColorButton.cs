using UnityEngine;
using System.Collections;

public class ColorButton : MonoBehaviour {
	public GUIText myText;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		//myText.fontStyle = FontStyle.Italic;
	}

	void OnMouseUp(){
		/*myText.fontStyle = FontStyle.Normal;
		if(Selector.Instance.selected != null){
			SpriteRenderer selectedRenderer = Selector.Instance.selected.GetComponent<SpriteRenderer>();
			selectedRenderer.color = myText.color;
		}*/
	}
}
