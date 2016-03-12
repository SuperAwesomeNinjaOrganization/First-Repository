using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateUI : MonoBehaviour {

	[SerializeField]
	private Text scoreText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + GameLogic.Score.ToString (); //display score on screen
	}
}
