using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour {

	private GameObject target; 
	private Animator animator; 
	private starDisplay starDisplay; 
	public int starCost; 

	void Start () {
		animator = GetComponent<Animator>();
		starDisplay = GameObject.FindObjectOfType<starDisplay>();  
	}

	void Update () {
		if (!target) {
			animator.SetBool ("isAttacking", false); 
		}  	
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

	void addStars (int amout) {
		starDisplay.addStars (amout); 
	}
}
