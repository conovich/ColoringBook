using UnityEngine;
using System.Collections;

public class ColorableButton : MonoBehaviour {
	public GameObject myColorable;
	public GUIText myText;

	private SpriteRenderer mySpriteRenderer;
	string originalText;

	// Use this for initialization
	void Start () {
		mySpriteRenderer = myColorable.GetComponent<SpriteRenderer>();
		originalText = myText.text;
	}
	
	// Update is called once per frame
	void Update () {
		if(Selector.Instance.selected == myColorable){
			if(mySpriteRenderer.color != Color.white){
				myText.color = mySpriteRenderer.color;
			}
			myText.fontStyle = FontStyle.Italic;
		}
		else{
			myText.fontStyle = FontStyle.Normal;
			myText.color = Color.black;
			myText.text = originalText;
		}
	}

	void OnMouseUp(){
		if(myColorable != null){
			Selector.Instance.SelectColorable(myColorable);
		}
	}
}
