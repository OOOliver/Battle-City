using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
	public static MusicController musicIns;

	public AudioClip[] musics;

	private AudioSource AS;

	// Use this for initialization
	void Start () {
		musicIns = this;
		AS = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Awake(){
		
	}

	public void playMusic(int i){
		this.AS.clip = musics [i];
		this.AS.Play ();
	}
}
