using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Die : MonoBehaviour{
	void OnGUI(){
			GUI.Box (new Rect (10, 10, 100, 90), "" + Time.time);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Enemy") {
			Destroy (gameObject);
			Time.timeScale = 0;
		}
	}
}

