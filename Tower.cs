using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tower : MonoBehaviour{
	private int tHP = 125;
	public Rigidbody2D missile;
	public GameObject blank;
	public GameObject tboom;

	void Update(){
		isDeath ();
	}
	void Start(){
		InvokeRepeating ("stillShot", 1, 1.75f);
	}
	void shotMissile(){
		Rigidbody2D missileInstance;
		missileInstance = Instantiate (missile, blank.transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
		if (gameObject.tag == "bossTowerUp") {
			missileInstance.velocity = new Vector2 (0, -20f);
		} else if (gameObject.tag == "bossTowerDown") {
			missileInstance.velocity = new Vector2 (0, 20f);
		} else if (gameObject.tag == "bossTowerLeft") {
			missileInstance.velocity = new Vector2 (20f, 0);
		} else if (gameObject.tag == "bossTowerRight") {
			missileInstance.velocity = new Vector2 (-20f, 0);
		}
	}

	void stillShot(){
		shotMissile ();
		Invoke ("shotMissile", 0.2f);
		Invoke ("shotMissile", 0.4f);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "hball") {
			if (!Level3.Boss2) {
				tHP = tHP - Move.power;
			}
			Destroy (other.gameObject);
		} else if (other.gameObject.tag == "eball") {
			Destroy (other.gameObject);
		}
	}

	void isDeath(){
		if (tHP <= 0) {
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
			Instantiate (tboom, transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
			Destroy (gameObject);
		}
	}
}

