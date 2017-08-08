using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Buttons : MonoBehaviour {

	private Buttons[] buttomArray; 
	public static GameObject selectedDefender; 
	public GameObject prefab; 
	private Text cost; 

	void Start() {
		cost = GetComponentInChildren<Text>(); 
		int prefabCost = prefab.GetComponent<Defenders>().starCost; 
		cost.text = prefabCost.ToString(); 
		buttomArray = FindObjectsOfType<Buttons>(); 
	}

	void OnMouseDown () {

		foreach (Buttons thisButtom in buttomArray) {
			thisButtom.GetComponent<SpriteRenderer>().color = Color.black; 
		}

		GetComponent<SpriteRenderer>().color = Color.white; 
		selectedDefender = prefab; 
	} 
}
