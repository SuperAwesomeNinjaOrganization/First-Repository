using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject ninjaPrefab;

	public GameObject ninjaMeleePrefab;

	public GameObject poof;

	//player position
	//Vector3 playerPos = new Vector3 (0f,0f,20f);

	public GameObject player;

	//EnemyNinja enemyNinja = new EnemyNinja ();

	//public static Vector3 position = transform.position;

	public static int playerHP = 3;

	public static bool gameOver = false; //set to true when player hp = 0;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		gameOver = false;
		playerHP = 3;
		StartCoroutine ("SpawnEnemy");
	}
	
	// Update is called once per frame
//	void Update () {
//		if (gameOver) {
//			//PauseGame ();
//			//GameObject GG = GameObject.Find ("GameOverScreen");
//			//GG.Appear ();
//			//Application.LoadLevel ("TitleScene"); //change this to gameover/results screen?
//		}
//	}

	public void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Enemy Projectile") 
		{
			Debug.Log ("I've been Hit!");
			playerHP --;
			//Destry health Icons or set alpha = 0
			if (playerHP == 2) {
				GameObject hP3 = GameObject.Find ("HealthIcon3");
				Destroy (hP3);
			} else if (playerHP == 1) {
				GameObject hP2 = GameObject.Find ("HealthIcon2");
				Destroy (hP2);
			} else if (playerHP <= 0) {
				GameObject hP1 = GameObject.Find ("HealthIcon1");
				Destroy (hP1);
				gameOver = true;
			}
			//Destroy (col.gameObject);
		}
	}

	public void PauseGame (){
		Time.timeScale = 0f;
	}

	public void ResumeGame (){
		Time.timeScale = 1f;
	}

	private IEnumerator SpawnEnemy (){
		//randomly spawns enemies from specific locations
		while(!gameOver){
			int caseSwitch = UnityEngine.Random.Range(1,12);

			switch (caseSwitch) 
			{
			case 1: //Leftmost
				Instantiate (ninjaPrefab, new Vector3(-39f,-3f,0f), Quaternion.AngleAxis(180f,Vector3.up));
				//Debug.Log (caseSwitch);
				break;
			case 2: //Left
				Instantiate (ninjaPrefab, new Vector3(-32f,-5.5f,0f), Quaternion.AngleAxis(180f,Vector3.up));
				//Debug.Log (caseSwitch);
				break;
			case 3: //groundouter
				Instantiate (ninjaPrefab, new Vector3(-25f,-16f,0f), Quaternion.AngleAxis(180f,Vector3.up));
				//Debug.Log (caseSwitch);
				break;
			case 4: //groundinner
				Instantiate (ninjaPrefab, new Vector3(-19f,-16f,0f), Quaternion.AngleAxis(180f,Vector3.up));
				break;
			case 5: //centerleft
				Instantiate (poof, new Vector3 (-5f, -4.5f, 39f), Quaternion.identity);
				Instantiate (ninjaMeleePrefab, new Vector3 (-5f, -4.5f, 39f), Quaternion.LookRotation (player.transform.position + new Vector3 (-5f, -4.5f, 39f)));
				EnemyMelee.JumpAttack ();
				//EnemyNinja.speed = 20f;
				break;
			case 6: //center
				Instantiate (poof, new Vector3 (0f,-1.6f,39f), Quaternion.identity);
				Instantiate (ninjaMeleePrefab, new Vector3(0f,-1.6f,39f), Quaternion.LookRotation(player.transform.position + new Vector3(0f,-1.6f,39f)));
				EnemyMelee.JumpAttack ();
				//EnemyNinja.speed = 20f;
				break;
			case 7: //centerright
				Instantiate (poof, new Vector3 (5f,-4.5f,39f), Quaternion.identity);
				Instantiate (ninjaMeleePrefab, new Vector3(5f,-4.5f,39f), Quaternion.LookRotation(player.transform.position + new Vector3(5f,-4.5f,39f)));
				EnemyMelee.JumpAttack ();
				//EnemyNinja.speed = 20f;
				break;
			case 8: //groundinner
				Instantiate (ninjaPrefab, new Vector3(19f,-16f,0f), Quaternion.AngleAxis(180f,Vector3.up));
				break;
			case 9: //groundouter
				Instantiate (ninjaPrefab, new Vector3(25f,-16f,0f), Quaternion.AngleAxis(180f,Vector3.up));
				break;
			case 10: //Right
				Instantiate (ninjaPrefab, new Vector3 (32f, -5.5f, 0f), Quaternion.AngleAxis(180f,Vector3.up));
				break;
			case 11: //Rightmost
				Instantiate (ninjaPrefab, new Vector3(39f,-3f,0f), Quaternion.AngleAxis(180f,Vector3.up));
				break;
			}
			yield return new WaitForSeconds(2);
		}

	}

}
