using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroy : MonoBehaviour{
	public float x;
	public float y;
	void DestroyByCamera(){
		if (transform.position.x > x || transform.position.x < -x) {
			Destroy (gameObject);
		}
		if (transform.position.y > y || transform.position.y < -y) {
			Destroy (gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "hball") {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		if (other.gameObject.tag == "eball") {
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
	void Update(){
		DestroyByCamera ();
	}
}

