using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {

	private float walkSpeed; 
	private GameObject target; 
	private Animator animator; 
	public float seenEverySecond; 

	void Start () {
		animator = GetComponent<Animator>(); 
	}

	void Update () {
		transform.Translate (Vector3.left * walkSpeed * Time.deltaTime); 
		if (!target) {
			animator.SetBool ("isAttacking", false); 
		}  	
	}

	public void setWalkSpeed(float newSpeed) {
		walkSpeed = newSpeed;   
	}

	public void StrikeCurrentTarget (float damage) {  
		if (target) {
			Health health = target.GetComponent<Health>(); 
			if (health) {
				health.dealDamage (damage); 
			}
		}
	}

	public void attack (GameObject obj) { 
		target = obj; 
	}
}
