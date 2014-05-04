using UnityEngine;
using System.Collections;

public class ColorableButtonMaker : MonoBehaviour {
	GameObject[] Colorables;
	public GameObject ColorableButtonPrefab;

	// Use this for initialization
	void Start () {
		Colorables = GameObject.FindGameObjectsWithTag("Colorable");
		MakeButtons();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MakeButtons(){
		for(int i = 0; i < Colorables.Length; i++){

		}
	}
}
