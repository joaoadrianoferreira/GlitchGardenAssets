using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizzard : MonoBehaviour {

	private Animator anim; 
	private Attacker attacker; 

	void Start () {
		anim = GetComponent<Animator>(); 
		attacker = GetComponent<Attacker>(); 
	}

	void OnTriggerEnter2D(Collider2D collider) {
		GameObject obj = collider.gameObject; 
		if (!obj.GetComponent<Defenders>()) {
			return; 
		} else {
			anim.SetBool ("isAttacking", true); 
			attacker.attack(obj); 
		}
	}
}
