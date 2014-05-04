using UnityEngine;
using System.Collections;

public class GlobalColors : MonoBehaviour {
	public Color yellow;
	public Color green;
	public Color blue;
	public Color pink;

	private static GlobalColors _instance;
	public static GlobalColors Instance{
		get{
			return _instance;
		}
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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
