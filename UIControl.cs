using UnityEngine;
using System.Collections;


public class UIControl : MonoBehaviour {
	 
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

	public void ConditionalReturn() {
		GameObject titleScreen = GameObject.Find ("TitleScreen");
		CanvasGroup titleCanvasGroup = titleScreen.GetComponent<CanvasGroup> ();

		GameObject gameScreen = GameObject.Find ("GameScreen");
		CanvasGroup gameScreenCanvasGroup = gameScreen.GetComponent<CanvasGroup> ();

		GameObject pauseScreen = GameObject.Find ("PauseScreen");
		CanvasGroup pauseScreenCanvasGroup = pauseScreen.GetComponent<CanvasGroup> ();

		CanvasGroup canvasGroup = GetComponent<CanvasGroup> ();

		if (titleCanvasGroup.alpha == 1) {
			transform.Translate (0f, 1080f, 0f);
			//transform.position = new Vector3(0,1080,0);
			canvasGroup.alpha = 0;
			canvasGroup.interactable = false;
			//titleScreen.transform.Translate (0f, -419.625f, 0f);
			titleScreen.transform.localPosition = new Vector3(0,0,0);
			titleCanvasGroup.interactable = true;
		} else {
			transform.Translate (0f, 1080f, 0f);
			//transform.position = new Vector3(0,1080,0);
			canvasGroup.alpha = 0;
			canvasGroup.interactable = false;
			//gameScreen.transform.Translate (0f, -419.625f, 0f);
			gameScreen.transform.localPosition = new Vector3(0,0,0);
			gameScreenCanvasGroup.interactable = true;
			//pauseScreen.transform.Translate (0f, -419.625f, 0f);
			pauseScreen.transform.localPosition = new Vector3(0,0,0);
			pauseScreenCanvasGroup.interactable = true;
		}
	}
}
