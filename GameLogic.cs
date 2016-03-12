using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

	public static int HighScore = 0;

	public static int Score = 0;

	//SceneManager scManager = new SceneManager();

	// Use this for initialization
	void Start () {
		HighScore = PlayerPrefs.GetInt ("score");
		Score = 0;
	}
//	
	// Update is called once per frame
	void Update () {
		if (GameController.gameOver == true) {
			PlayerPrefs.SetInt ("score", HighScore);
			PlayerPrefs.Save ();
		} 
	
	}


	public void StartGame() {
		Application.LoadLevel ("GameScene"); //change Application.LoadLevel to SceneManager.LoadScene instead?

	}

	public void GoToTitle() {
		Application.LoadLevel ("TitleScene");
	}

	public void ExitGame () {
		Debug.Log ("see if its working");
		Application.Quit ();
	}
}
