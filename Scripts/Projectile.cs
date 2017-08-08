using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed, damage; 
	private Defenders defender; 

	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);  
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Attacker attacker = collider.GetComponent<Attacker>(); 
		Health health = collider.GetComponent<Health>(); 

		if (attacker && health) {
			health.dealDamage(damage); 
			Destroy(gameObject); 
		}
	}
}
