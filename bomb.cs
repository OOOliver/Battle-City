using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bomb : MonoBehaviour{
	public GameObject biubiubiu;
	public float radius;
	void Start(){
		Invoke ("destruct", 5);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "hball") {
			Collider2D[] others = Physics2D.OverlapCircleAll (transform.localPosition, radius);
			foreach (Collider2D cd in others) {
				if (cd.gameObject.tag == "Tank") {
					Instantiate (biubiubiu, cd.transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
					Destroy (cd.gameObject);
				}
			}
			Move.hasBomb = false;
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
	void destruct(){
		Collider2D[] others = Physics2D.OverlapCircleAll (transform.localPosition, radius);
		foreach (Collider2D cd in others) {
			if (cd.gameObject.tag == "Tank") {
				Instantiate (biubiubiu, cd.transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
				Destroy (cd.gameObject);
			}
		}
		Move.hasBomb = false;
		Destroy (gameObject);
	}
}

