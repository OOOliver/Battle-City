using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destroy : MonoBehaviour{
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "eball") {
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}

