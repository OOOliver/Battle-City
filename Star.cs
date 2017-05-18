using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Star : MonoBehaviour{
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Level3.startBoss = true;
			Destroy (gameObject);
		}
	}
}

