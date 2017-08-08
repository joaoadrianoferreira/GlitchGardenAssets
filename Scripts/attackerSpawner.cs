using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackerSpawner : MonoBehaviour {

	public GameObject[] spawers; 

	void Update () {
		foreach (GameObject myGameObject in spawers) {
			if (isTimeToSpawn (myGameObject)) {
				Spawn (myGameObject); 
			}
		}
	}

	bool isTimeToSpawn (GameObject myGameObject) {
		Attacker attacker = myGameObject.GetComponent<Attacker>(); 
		float meanSpawnDelay = attacker.seenEverySecond; 
		float spawnsPerSecond = 1 / meanSpawnDelay; 
		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		} 

		float threshold = spawnsPerSecond * Time.deltaTime / 5; 

		return (Random.value < threshold); 

	}

	void Spawn (GameObject myGameObject) { 
		GameObject myAttacker = Instantiate (myGameObject) as GameObject;
		myAttacker.transform.parent = transform; 
		myAttacker.transform.position = transform.position; 
	}
}
