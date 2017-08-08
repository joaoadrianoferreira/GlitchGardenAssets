using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	private Camera myCamera; 
	private GameObject defendersParent; 
	private starDisplay starDisplay; 
	private int defenderCost; 

	// Use this for initialization
	void Start () {
		starDisplay = FindObjectOfType<starDisplay>(); 
		myCamera = FindObjectOfType<Camera>(); 
		defendersParent = GameObject.Find ("Defenders"); 
		if (!defendersParent) {
			defendersParent = new GameObject ("Defenders"); 
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		if (Buttons.selectedDefender) {
			defenderCost = Buttons.selectedDefender.GetComponent<Defenders>().starCost; 
			Vector2 pos = snapToGrid(calculateWorldPointofMouseClick ()); 
			if (starDisplay.useStars(defenderCost) == starDisplay.Status.SUCESS) {
				GameObject defender = Instantiate (Buttons.selectedDefender, pos, Quaternion.identity) as GameObject;
				defender.transform.parent = defendersParent.transform; 
			} else {
				Debug.Log ("Insuficinte Stars"); 
			}
		} 

	}
	 
	Vector2 snapToGrid (Vector2 rawPostion) {
		float xPosition = Mathf.RoundToInt (rawPostion.x); 
		float yPosition = Mathf.RoundToInt (rawPostion.y); 
		Vector2 newVector2 = new Vector2 (xPosition, yPosition); 
		return newVector2; 
	}

	Vector2 calculateWorldPointofMouseClick () {
		float mouseX = Input.mousePosition.x; 
		float mouseY = Input.mousePosition.y; 
		float distance = 10.0f; 
		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distance); 
		Vector2 worldPosition = myCamera.ScreenToWorldPoint(weirdTriplet); 
		return worldPosition; 
	}
}
