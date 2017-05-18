using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ep : MonoBehaviour{
	void Start(){
		Destroy (gameObject, 3);
	}

	void FixedUpdate(){
		transform.Rotate (new Vector3 (0, 0, 90) * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "hball" || other.gameObject.tag == "eball") {
			Destroy (other.gameObject);
		}
	}
}

