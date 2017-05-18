using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class o2Wall : Wall{
	public static bool open2 ;
	private Animator ani;
	void Start(){
		open2 = false;
		ani = GetComponent<Animator> ();
	}
	void Update(){
		openWall ();
	}
	void openWall(){
		if (open2 == true) {
			ani.SetBool ("open", true);
			Invoke ("closeWall2", 2);
		}
	}
	void closeWall2(){
		ani.SetBool ("open", false);
	}
}

