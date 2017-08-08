using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Defenders))]
public class Stone : MonoBehaviour {

	private Animator anim; 
	private Defenders defender; 

	void Start () {
		anim = GetComponent<Animator>(); 
		defender = GetComponent<Defenders>(); 
	} 

	void OnTriggerEnter2D(Collider2D collider) {
		GameObject obj = collider.gameObject; 
		if (!obj.GetComponent<Attacker>() || obj.GetComponent<Fox>()) {
			return; 
		} else {
			anim.SetBool ("isAttacking", true); 
			defender.attack(obj); 
		}
	}
}
