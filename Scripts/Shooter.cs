using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun; 
	private GameObject projectileParent; 
	private Animator animator; 
	private attackerSpawner myLaneSpawner;   

	void Start () { 
		animator = FindObjectOfType<Animator>(); 
		projectileParent = GameObject.Find ("Projectiles"); 
		if (!projectileParent) {
			projectileParent = new GameObject ("Projectiles"); 
		}
		setMyLaneSpawner(); 
	}


	void Update () {
		if (isAttackerInLane() && !animator.GetBool("isAttacking")) {
			animator.SetBool ("isFiring", true); 
		} else {
			animator.SetBool ("isFiring", false); 
		}
	}

	bool isAttackerInLane () {
		if (myLaneSpawner.transform.childCount <= 0) {
			return false; 
		} 
		foreach (Transform attacker in myLaneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true; 
			}
		}
		return false; 
	}

	void setMyLaneSpawner () {
		attackerSpawner[] spawnerArray = GameObject.FindObjectsOfType<attackerSpawner>(); 
		foreach (attackerSpawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner; 
				return; 
			}
		}
		Debug.LogError ("Can't find spawner lane"); 
	}

	private void fire() {
		GameObject newProjectile = Instantiate(projectile) as GameObject; 
		newProjectile.transform.parent = projectileParent.transform; 
		newProjectile.transform.position = gun.transform.position;  
	}
}
