using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ring : MonoBehaviour{
	public GameObject rboom;
	private GameObject player;
	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
		Destroy (gameObject, 5);
	}
	void FixedUpdate(){
		transform.Rotate (new Vector3 (0, 0, 90) * Time.deltaTime);
		transform.localPosition = player.transform.localPosition;
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "eball" || other.gameObject.tag == "bball") {
			Destroy (other.gameObject);
		} else if (other.gameObject.tag == "Tank") {
			if (Level1.third1 == false) {
				Level1.climber++;
			} else if (Level1.third1 == true && Level2.third2 == false) {
				Level2.end++;
			}
			Information.Score += 1000;
			Instantiate (rboom, other.gameObject.transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
			Destroy (other.gameObject);
		}
	}
}

