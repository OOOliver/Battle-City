using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class oWall : Wall{
	public bool open = false;
	private Animator ani;
	void Start(){
		ani = GetComponent<Animator> ();
	}
	void Update(){
		openWall ();
	}
	void openWall(){
		if (open == true) {
			ani.SetBool ("open", true);
		}
	}
}

