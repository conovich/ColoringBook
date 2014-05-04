using UnityEngine;
using System.Collections;

public class Bucket : MonoBehaviour {
	public ColorBar MyColorBar;
	public GUIText MyColorLabel;

	private Color MyColor = Color.white;
	private int particleCount;

	// Use this for initialization
	void Start () {
		SetColors();
	}

	// Update is called once per frame
	void Update () {
		if(particleCount == 3){
			AddColorBarPiece();
			particleCount = 0;
		}
	}

	void SetColors(){
		switch(gameObject.tag){
		case "Yellow":
			SetMyColor(GlobalColors.Instance.yellow);
			SetTextColor(GlobalColors.Instance.yellow);
			break;
		case "Blue":
			SetMyColor(GlobalColors.Instance.blue);
			SetTextColor(GlobalColors.Instance.blue);
			break;
		case "Green":
			SetMyColor(GlobalColors.Instance.green);
			SetTextColor(GlobalColors.Instance.green);
			break;
		case "Pink":
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

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == gameObject.tag){ //colors match
			particleCount++;
		}
	}

	void AddColorBarPiece(){
		MyColorBar.SetNextPieceColor(MyColor);
	}

	void SubstractColorBarPiece(){
		MyColorBar.RemoveNextPieceColor();
	}

	
}
