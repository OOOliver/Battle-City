using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class o2Wall : Wall{
	public bool open2 = false;
	private Animator ani;
	void Start(){
		ani = GetComponent<Animator> ();
	}
	void Update(){
		openWall ();
	}
	void openWall(){
		if (open2 == true) {
			ani.SetBool ("open", true);
		}
	}
}

