using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GGScript : MonoBehaviour {

	[SerializeField]
	private Text scText;

	private int tempHighScore;

	// Use this for initialization
	void Start () {
		tempHighScore = GameLogic.HighScore;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameController.gameOver == true) {
			Appear ();
			Time.timeScale = 0f;
			if (GameLogic.Score > tempHighScore) {
				GameLogic.HighScore = GameLogic.Score;
				scText.text = "New High Score: " + GameLogic.HighScore.ToString ();
			} else {
				scText.text = "Score: " + GameLogic.Score.ToString ();
			}
			//GameController.PausedGame ();
		} 
	}

	public void Disappear() { //This will make current screen invisible and move it off screen
		CanvasGroup canvasGroup = GetComponent<CanvasGroup> ();
		transform.Translate(0f,1080f,0f); //419.625f is the equivalent to 1080f if run-time is not set to "Maximize on play"
		//transform.position = new Vector3(0,1080,0);
		canvasGroup.alpha = 0;
		canvasGroup.interactable = false;

	}

	public void Appear() {
		CanvasGroup canvasGroup = GetComponent<CanvasGroup> ();
		//transform.Translate(0f,-1080f,0f);
		transform.localPosition = new Vector3(0,0,0);
		canvasGroup.alpha = 1;
		canvasGroup.interactable = true;
	}

	//	public void SetGameScreenInteractabilityOnPause() {
	//		CanvasGroup canvasGroup = GetComponent<CanvasGroup> ();
	//		canvasGroup.interactable = false;
	//	}

	public void SetAside() {
		CanvasGroup canvasGroup = GetComponent<CanvasGroup> ();
		transform.Translate(0f,1080f,0f);
		//transform.position = new Vector3(0,1080,0);
		canvasGroup.alpha = 1; //keeps visible but set aside, allows for prev active screen check
		canvasGroup.interactable = false;
	}

}
