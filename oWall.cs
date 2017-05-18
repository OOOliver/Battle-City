using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class oWall : Wall{
	public static bool open ;
	private Animator ani;
	void Start(){
		open = false;
		ani = GetComponent<Animator> ();
	}
	void Update(){
		openWall ();
	}
	void openWall(){
		if (open == true) {
			ani.SetBool ("open", true);
			Invoke ("closeWall", 2);
		}
	}
	void closeWall(){
		ani.SetBool ("open", false);
	}
}

