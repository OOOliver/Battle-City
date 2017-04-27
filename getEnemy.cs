using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getEnemy: MonoBehaviour{
	public Rigidbody2D enemy;
	public Vector3 enemyValue;

	void enemySpawn(){
		Rigidbody2D enemyInstance;
		Vector3 enemyPosition = new  Vector3 (Random.Range (-enemyValue.x, enemyValue.x), enemyValue.y, 0);
		enemyInstance = Instantiate (enemy,enemyPosition, Quaternion.Euler (new Vector3 (0, 0, 0)));
	}

	void Start(){
		enemySpawn ();
		InvokeRepeating("enemySpawn",3,3);
	}
		
}

