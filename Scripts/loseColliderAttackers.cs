using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loseColliderAttackers : MonoBehaviour {

	private LevelManager levelManager; 

	void Start() {
		levelManager = FindObjectOfType<LevelManager>(); 
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Destroy(collider.gameObject); 
		levelManager.LoadLevel("Lose"); 
	}
}
