using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playButton: MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Click(){
		Application.LoadLevel("roguelike");
	}
}
