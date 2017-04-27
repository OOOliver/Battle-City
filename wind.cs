using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class wind : MonoBehaviour{
	private GameObject player;
	void Start(){
		player = GameObject.FindGameObjectWithTag("Player");
		Destroy (gameObject, 5);
	}
	void FixedUpdate(){
		transform.localPosition = new Vector3 (player.transform.localPosition.x - 0.5f, player.transform.localPosition.y, player.transform.localPosition.z);
		transform.localEulerAngles = player.transform.localEulerAngles;
	}
}

