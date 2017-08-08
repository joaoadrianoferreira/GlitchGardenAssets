using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeGame : MonoBehaviour {

	private starDisplay starDisplay; 

	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<starDisplay>(); 
		starDisplay.totalStars = 100; 
	}
}
