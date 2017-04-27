using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fire : MonoBehaviour{
	private GameObject player;
	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
		Destroy (gameObject, 5);
	}
	void FixedUpdate(){
		transform.localPosition = player.transform.localPosition;
		transform.localEulerAngles = player.transform.localEulerAngles;
	}
}

