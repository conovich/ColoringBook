using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {
	public GameObject selected;
	GameObject[] Colorables;

	private static Selector _instance;
	public static Selector Instance{
		get{ return _instance; }
	}

	void Awake(){
		if(_instance != null){
			Debug.Log("Instance already exists!");
			return;
		}
		_instance = this;
	}


	// Use this for initialization
	void Start () {
		Colorables = GameObject.FindGameObjectsWithTag("Colorable");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SelectColorable(int index){
		Colorable myColorable;
		myColorable = (Colorables[index]).GetComponent<Colorable>();
		
		ToggleSelected();
		
		selected = Colorables[index];
		myColorable.ToggleSelector(true);
	}

	int FindColorableIndex(GameObject myColorable){
		for(int i = 0; i < Colorables.Length; i++){
			if(Colorables[i] == myColorable){
				return i;
			}
		}
		return -1;
	}

	public void SelectColorable(GameObject myColorable){
		int index = FindColorableIndex(myColorable);
		if(index != -1){
			SelectColorable(index);
		}
	}

	void ToggleSelected(){
		if(selected != null){
			Colorable selectedColorable = selected.GetComponent<Colorable>();
			selectedColorable.ToggleSelector(false);
		}
	}
}
