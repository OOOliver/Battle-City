using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossBullet : MonoBehaviour{
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "hball") {
			Destroy (other.gameObject);
		} else if (other.gameObject.tag == "eball") {
			Destroy (other.gameObject);
		}
	}
}

