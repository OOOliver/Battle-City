using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemyMove : MonoBehaviour{
	private GameObject heroObj;
	private bool eright = false;
	private bool eleft = false;
	private bool eup = false;
	private bool edown= false;
	private float erandom;
	public Rigidbody2D bullet;
	private float bspeed = 20f;
	private float bspeed2 = -20f;
	public GameObject eshot;
	public GameObject eboom;
	private int EHP = 50;
	private enum forward
	{
		up,
		down,
		left,
		right
	};

	void Start(){
		InvokeRepeating ("eMove", 0, 1.5f);
		InvokeRepeating ("shoot", 1, 2);
	}

	void Update(){
		isEnemyDeath ();
		stillMove ();

	}

	void eMove(){
		erandom = Random.Range (0, 6);
		heroObj = GameObject.Find ("Tank");
		if (heroObj != null) {
			float ehy = transform.position.y - heroObj.transform.position.y;
			float ehx = transform.position.x - heroObj.transform.position.x;
			if (erandom >= 0 && erandom < 1) {
				setForward (forward.up);
			} 
			if (erandom >= 1 && erandom < 2) {
				setForward (forward.down);
			}
			if (erandom >= 2 && erandom < 3) {
				setForward (forward.right);
			}
			if (erandom >= 3 && erandom < 4) {
				setForward (forward.left);
			}
			if (erandom >= 4 && erandom <= 6) {
				if (ehy * ehy > ehx * ehx && ehy > 0) {
					setForward (forward.down);
				}
				if (ehy * ehy > ehx * ehx && ehy <= 0) {
					setForward (forward.up);
				}
				if (ehy * ehy <= ehx * ehx && ehx > 0) {
					setForward (forward.left);
				}
				if (ehy * ehy <= ehx * ehx && ehx <= 0) {
					setForward (forward.right);
				}
			}
		}
	}
		

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Tank") {
			if (eup == true) {
				setForward (forward.down);
			}
			else if (eleft == true) {
				setForward (forward.right);
			}
			else if (edown == true) {
				setForward (forward.up);

			}
			else if (eright == true) {
				setForward (forward.left);
			}
		}
		else if (other.gameObject.name == "wall") {
			if (eup == true) {
				setForward (forward.down);
			}
			else if (eleft == true) {
				setForward (forward.right);
			}
			else if (edown == true) {
				setForward (forward.up);

			}
			else if (eright == true) {
				setForward (forward.left);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "hball") {
			EHP = EHP - Move.power;
			Destroy (other.gameObject);
		}
		else if (other.gameObject.tag == "eball") {
			Destroy (other.gameObject);
		}
	}

	void setForward(forward fw){
		switch (fw) 
		{
		case forward.up:
			eleft = false;
			eright = false;
			eup = true;
			edown = false;

			transform.localEulerAngles = new Vector3 (0, 0, 0);
			break;
		case forward.down:
			eleft = false;
			eright = false;
			eup = false;
			edown = true;

			transform.localEulerAngles = new Vector3 (0, 0, 180);
			break;
		case forward.right:
			eleft = false;
			eright = true;
			eup = false;
			edown = false;

			transform.localEulerAngles = new Vector3 (0, 0, 270);
			break;
		case forward.left:
			eleft = true;
			eright = false;
			eup = false;
			edown = false;

			transform.localEulerAngles = new Vector3 (0, 0, 90);
			break;
		}
	}

	void stillMove(){
		if (eup == true) {
			transform.position = transform.position+new Vector3(0,0.1f,0);
		}
		if (edown == true) {
			transform.position = transform.position+new Vector3(0,-0.1f,0);
		}
		if (eright == true) {
			transform.position = transform.position+new Vector3(0.1f,0,0);
		}
		if (eleft == true) {
			transform.position = transform.position+new Vector3(-0.1f,0,0);
		}
	}

	void shoot(){
		Rigidbody2D ebinstance;
		if(eright == true){
			ebinstance = Instantiate(bullet,eshot.transform.position,Quaternion.Euler(new Vector3(-1,0,0)));
			ebinstance.velocity = new Vector2(bspeed,0);
		}
		if(eleft == true){
			ebinstance = Instantiate(bullet,eshot.transform.position,Quaternion.Euler(new Vector3(-1,0,0)));
			ebinstance.velocity = new Vector2(bspeed2,0);
		}

		if(eup== true){
			ebinstance = Instantiate(bullet,eshot.transform.position,Quaternion.Euler(new Vector3(-1,0,0)));
			ebinstance.velocity = new Vector2(0,bspeed);
		}
		if(edown == true){
			ebinstance = Instantiate(bullet,eshot.transform.position,Quaternion.Euler(new Vector3(-1,0,0)));
			ebinstance.velocity = new Vector2(0,bspeed2);
		}
	}

	void isEnemyDeath(){
		if (EHP == 0) {
			Instantiate (eboom, transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
			Destroy (gameObject);
		}
	}
}

