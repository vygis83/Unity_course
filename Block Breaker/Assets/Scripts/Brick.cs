﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;

	private int timesHit;
	private LevelManager levelManager; 
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		timesHit = 0;
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (isBreakable) {
			HandleHits ();
			AudioSource.PlayClipAtPoint (crack, transform.position, 0.3f);
		}
	}

	void HandleHits () {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}

	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}

	void SimulateWin () {
		levelManager.LoadNextLevel ();
	}
}