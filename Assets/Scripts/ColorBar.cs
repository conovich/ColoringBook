using UnityEngine;
using System.Collections;

public class ColorBar : MonoBehaviour {
	public GameObject[] Pieces;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetNextPieceColor(Color newColor){
		if(newColor.a == 0){
			newColor.a = 1.0f;
		}


		for(int i = 0; i < Pieces.Length; i++){
			SpriteRenderer pieceRenderer = Pieces[i].GetComponent<SpriteRenderer>();
			if(pieceRenderer.color == Color.white){
				SetPieceColor(i, newColor);
				return;
			}
		}
	}

	public void RemoveNextPieceColor(){
		for(int i = Pieces.Length - 1; i >= 0; i--){
			SpriteRenderer pieceRenderer = Pieces[i].GetComponent<SpriteRenderer>();
			if(pieceRenderer.color != Color.white){
				SetPieceColor(i, Color.white);
				return;
			}
		}
	}

	public void SetPieceColor(int index, Color newColor){
		SpriteRenderer pieceRenderer = Pieces[index].GetComponent<SpriteRenderer>();
		pieceRenderer.color = newColor;
	}

	public void ResetAllColors(){
		for(int i = 0; i < Pieces.Length; i++){
			SpriteRenderer pieceRenderer = Pieces[i].GetComponent<SpriteRenderer>();
			pieceRenderer.color = Color.white;
		}
	}


}
