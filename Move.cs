using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour{
	private bool right = false;
	private bool left = false;
	private bool up = false;
	private bool down= false;
	public Rigidbody2D orb;
	private float orbspeed = 20f;
	private float orbspeed2 = -20f;
	public GameObject shot;
	private float nextFire;
	public float fireRate;
	public GameObject boom;
	private int PHP = 100;
	private bool death = false;
	public static int power = 25;
	public GameObject shield;
	public GameObject windfury;
	public GameObject superfire;
	public GameObject pow;
	private int bombCount = 0;
	public static bool hasBomb = false;
	void Start(){

	}

	void Update(){
		isDeath ();	
	}

	void FixedUpdate(){
		MoveCharacter ();
		shoot ();
	}

	void MoveCharacter(){
		if (Input.GetKey (KeyCode.D)) {
			left = false;
			right = true;
			up = false;
			down = false;
			transform.position = transform.position + new Vector3 (0.2f, 0, 0);
			transform.localEulerAngles = new Vector3 (0, 0, -90);
		} else if (Input.GetKey (KeyCode.S)) {
			left = false;
			right = false;
			up = false;
			down = true;
			transform.position = transform.position + new Vector3 (0, -0.2f, 0);
			transform.localEulerAngles = new Vector3 (0, 0, -180);
		} else if (Input.GetKey (KeyCode.A)) {
			left = true;
			right = false;
			up = false;
			down = false;
			transform.position = transform.position + new Vector3 (-0.2f, 0, 0);
			transform.localEulerAngles = new Vector3 (0, 0, 90);
		} else if (Input.GetKey (KeyCode.W)) {
			left = false;
			right = false;
			up = true;
			down = false;
			transform.position = transform.position + new Vector3 (0, 0.2f, 0);
			transform.localEulerAngles = new Vector3 (0, 0, 0);
		} else if (Input.GetKey (KeyCode.K) && hasBomb == false && bombCount >= 1) {
			Instantiate (pow, transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
			bombCount--;
			hasBomb = true;
		}

	}

	void shoot(){
		Rigidbody2D orbInstance;

		if(Input.GetButtonDown("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			if(right == true){
				orbInstance = Instantiate(orb,shot.transform.position,Quaternion.Euler(new Vector3(-1,0,0)));
				orbInstance.velocity = new Vector2(orbspeed,0);
			}
			if(left == true){
				orbInstance = Instantiate(orb,shot.transform.position,Quaternion.Euler(new Vector3(-1,0,0)));
				orbInstance.velocity = new Vector2(orbspeed2,0);
			}

			if(up== true){
				orbInstance = Instantiate(orb,shot.transform.position,Quaternion.Euler(new Vector3(-1,0,0)));
				orbInstance.velocity = new Vector2(0,orbspeed);
			}
			if(down == true){
				orbInstance = Instantiate(orb,shot.transform.position,Quaternion.Euler(new Vector3(-1,0,0)));
				orbInstance.velocity = new Vector2(0,orbspeed2);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "eball") {
			PHP = PHP - 25;
			Destroy (other.gameObject);
		} else if (other.gameObject.gameObject.tag == "power") {
			Instantiate (superfire, transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
			power = 50;
			Invoke ("resetPower", 5);
			Destroy (other.gameObject);
		} else if (other.gameObject.gameObject.tag == "windfury") {
			Instantiate (windfury, transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
			fireRate = 0.3f;
			Invoke ("resetRate", 5);
			Destroy (other.gameObject);
		} else if (other.gameObject.gameObject.tag == "heal") {
			PHP = PHP + 50;
			Destroy (other.gameObject);
		} else if (other.gameObject.gameObject.tag == "shield") {
			Instantiate (shield, transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
			Destroy (other.gameObject);
		} else if (other.gameObject.gameObject.tag == "bomb") {
			bombCount++;
			Destroy (other.gameObject);
		}
	}
	void isDeath(){
		if (PHP == 0) {
			death = true;
			Instantiate (boom, transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
			Destroy (gameObject);
		}
	}
	void resetPower(){
		power = 25;
	}
	void resetRate(){
		fireRate = 0.5f;
	}
}



