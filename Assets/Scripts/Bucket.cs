using UnityEngine;
using System.Collections;

public class Bucket : MonoBehaviour {
	public ColorBar MyColorBar;
	public GUIText MyColorLabel;
	public Color MyColor = Color.white;

	public int particleCount;


	public enum ColorName{
		Yellow,
		Green,
		Blue,
		Pink
	}

	public ColorName myColorName;

	// Use this for initialization
	void Start () {
		SetColors();
	}

	// Update is called once per frame
	void Update () {
		if(particleCount >= 3){
			AddColorBarPiece();
			particleCount = 0;
		}
	}

	void SetColors(){
		switch(myColorName){
		case ColorName.Yellow:
			SetMyColor(GlobalColors.Instance.yellow);
			SetTextColor(GlobalColors.Instance.yellow);
			break;
		case ColorName.Blue:
			SetMyColor(GlobalColors.Instance.blue);
			SetTextColor(GlobalColors.Instance.blue);
			break;
		case ColorName.Green:
			SetMyColor(GlobalColors.Instance.green);
			SetTextColor(GlobalColors.Instance.green);
			break;
		case ColorName.Pink:
			SetMyColor(GlobalColors.Instance.pink);
			SetTextColor(GlobalColors.Instance.pink);
			break;
		}
	}

	void SetMyColor(Color newColor){
		MyColor = newColor;
	}

	void SetTextColor(Color newColor){
		if(newColor.a < 1.0f){
			newColor.a = 1.0f;
		}
		MyColorLabel.color = newColor;
	}

	void OnTriggerEnter2D(Collider2D collider){
		if(collider.gameObject.tag == myColorName.ToString()){ //colors match
			particleCount++;
		}
	}

	void AddColorBarPiece(){
		MyColorBar.SetNextPieceColor(MyColor);
	}

	void SubstractColorBarPiece(){
		MyColorBar.RemoveNextPieceColor();
	}


	//work off this if I feel like doing select & tap to color.
	/*
	//if tapped and there exists a selected object!
	void OnMouseDown(){
		if(Selector.Instance.selected != null && MyColorBar.NumActive > 0){
			Colorable myColorable = Selector.Instance.selected.GetComponent<Colorable>();
			myColorable.MyBucket = this;
			myColorable.ColorObjectPermanently(MyColor);
		}
	}
	*/

	
}
