using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour{
	public Rigidbody2D bossBullet1;
	public GameObject bossShot1;
	public GameObject bossShot2;
	public GameObject bossShot3;
	public GameObject bboom;

	private int bossFirstHealth ;

	private bool sss;
	public static Animator hurtBoss;


	void Start(){
		bossFirstHealth = 500;
		sss = false;
		hurtBoss = GetComponent<Animator> ();
	}


	void Update(){
		thirdBoss ();
		if (Level3.Boss1 == true && Level3.Boss2 == false) {
			if (!sss) {
				InvokeRepeating ("stillSecondBossShot", 2, 2);
				sss = true;
			}

		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "hball") {
			if (Level3.Boss1 == true && Level3.Boss2 == false) {
				hurtBoss.SetBool ("hurt", true);
				hurtBoss.SetBool ("back", true);
				Invoke ("Hurt", 1);
				bossFirstHealth = bossFirstHealth - Move.power;
			}
			Destroy (other.gameObject);
		}
	}

	void secondBossShot(){
		Rigidbody2D midBullet = Instantiate (bossBullet1, bossShot1.transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
		midBullet.velocity = new Vector2(0,-20);
		Rigidbody2D leftBullet = Instantiate (bossBullet1, bossShot2.transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
		leftBullet.velocity = new Vector2(-12,-16);
		Rigidbody2D rightBullet = Instantiate (bossBullet1, bossShot3.transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
		rightBullet.velocity = new Vector2(12,-16);
	}

	void stillSecondBossShot(){
		secondBossShot ();
		Invoke ("secondBossShot", 0.5f);
		Invoke ("secondBossShot", 1.0f);
	}
		
	void Hurt(){
		hurtBoss.SetBool ("hurt", false);
	}

	void thirdBoss(){
		if (bossFirstHealth <= 0) {
			Level3.Boss2 = true;
			Instantiate (bboom, transform.position, Quaternion.Euler (new Vector3 (-1, 0, 0)));
			Information.Score += 10000;
			Destroy (gameObject);
		}
	}
	//三个阶段
	//第一个阶段boss应该是无敌的，但无法攻击，在地图中刷出几波特殊的小怪，分为撑过时间与击杀小怪两种方式来通过第一阶段
	//第二阶段，boss拥有一定生命值，可以攻击
	//同时刷新一定数目小怪，击杀小怪可以对boss造成伤害
	//动画不会做，小怪还是毫无价值地去死吧
	//第三阶段，boss拥有阶段性生命值，boss位置固定且发射弹幕，初定为由四波弹幕。如果实力不济至少写出两波弹幕
	//ZUN是天才，我放弃弹幕了
	//不仅如此，我还要做一个超简单的最终关~~~~~~~~
}

