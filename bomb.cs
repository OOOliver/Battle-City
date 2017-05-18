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
				if (Level1.third1 == false) {
					Level1.climber++;
				} else if (Level1.third1 == true && Level2.third2 == false) {
					Level2.end++;
				}
				Information.Score += 1000;
				Instantiate (biubiubiu, cd.transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
				Destroy (cd.gameObject);
			} else if (cd.gameObject.tag == "Tower") {
				if (gameObject.name == "tower1(Clone)") {
					GameObject lightwall1 = GameObject.Find ("lightWall1(Clone)");
					Destroy (lightwall1);
				} else if (gameObject.name == "tower2(Clone)") {
					GameObject lightwall2 = GameObject.Find ("lightWall2(Clone)");
					Destroy (lightwall2);
				} else {
					Level3.tower++;
				}
				Information.Score += 5000;
				Instantiate (biubiubiu, cd.transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
				Destroy (cd.gameObject);
			} 
		}
		Move.hasBomb = false;
		Destroy (gameObject);
	}
}

