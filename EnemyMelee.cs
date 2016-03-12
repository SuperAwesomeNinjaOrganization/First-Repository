using UnityEngine;
using System.Collections;

public class EnemyMelee : MonoBehaviour {

	public GameObject enemyShuriken;//enemy shuriken goes here

	public GameObject player;

	public GameObject poof;

	public GameObject targetIcon;

	//public Camera camera;

	//private Animation animationComponent;

	//private float newXPosition = 0f;
	public static float speed = 5f; //same speed so ninjas don't run into each other

	private bool stillAlive = true; //infinite loop till gameObject is destroyed?

	// Use this for initialization
	void Start () {
		StartCoroutine ("AttackPattern");
	}

	//Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position - transform.forward * speed * Time.deltaTime;
		//newPosition.z = transform.position.z; //keeps it from moving in the z axis
		transform.position = newPosition;
		//switch case for attack animation
		//if statement for leftlane, center, or rightlane
		if (gameObject.transform.position.z >= 309 || gameObject.transform.position.z <+ -15){
			Destroy (gameObject);
		}
	}

	//	public void OnCollisionEnter (Collision col)
	//	{
	//		if (col.gameObject.tag == "Projectile") 
	//		{
	//			Destroy (gameObject);
	//		}
	//	}

	//	private IEnumerator JumpOnHouse(Vector3 position)
	//	{
	//		for (float t = 0; t < 40f; t += Time.deltaTime) {
	//			Vector3 newXPosition = transform.position.x + 0.5f;
	//			transform.position.x = newXPosition;
	//			transform.position.y = (-0.1318) * (transform.position.x * transform.position.x) - (12.19 * transform.position.x) - 277.9;
	//			yield return 0;
	//		}
	//	}

	private IEnumerator AttackPattern (){
		while (stillAlive) {
			if (transform.position.z >= 50) {
				if (transform.position.x == -39 ||
					transform.position.x == -32 ||
					transform.position.x == -25 ||
					transform.position.x == -19 ||
					transform.position.x == 19 ||
					transform.position.x == 25 ||
					transform.position.x == 32 ||
					transform.position.x == 39) {
					//attack with shuriken
					ShurikenAttack();
				} 
			}
			yield return new WaitForSeconds(1);
		}
	}

	public void ShurikenAttack(){
		int caseSwitch = UnityEngine.Random.Range(1,3);

		switch (caseSwitch) 
		{
		case 1:
			//attack
			Debug.Log ("An attack is happening");
			//animationComponent.Play ("Throw_Shuriken_LeftLane");
			EnemyNinjaStar.Spawn (enemyShuriken, transform.position, player.transform.position - transform.position); //change targetpoint to location of player
			break;
		case 2:
			//do nothing
			Debug.Log("just relaxing");
			break;
		}
	}

	public static void JumpAttack(){
		Debug.Log ("RASHIDO");
		speed = 30f;
	}

	public void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "SlashRange") {
			//GameObject Reticle = Instantiate (targetIcon, transform.position + new Vector3(0f, 3f,-8f), Quaternion.AngleAxis(180f,Vector3.up)) as GameObject;
			GameObject Reticle = Instantiate(targetIcon) as GameObject;
			//GameObject canvas = GameObject.Find ("GameScreen");
			//Camera camera = Camera.main;
			//Vector2 screenPos = camera.WorldToScreenPoint (transform.position);
			Reticle.transform.SetParent (gameObject.transform, false);
			Reticle.transform.localRotation = Quaternion.AngleAxis (180f, Vector3.up);
			Reticle.transform.localPosition = new Vector3 (0f, 2f, -2f);

		}
		if (col.gameObject.tag == "Projectile" || col.gameObject.tag == "Player") 
		{
			Instantiate (poof, transform.position, Quaternion.identity);
			//Destroy (col.gameObject);
			if (col.gameObject.tag == "Projectile") {
				Destroy (gameObject);
				GameLogic.Score++;
			} else {
				Destroy (gameObject);
			}
		}
	}

	//	public void OnTriggerEnter (Collider col)
	//	{
	//		if (col.gameObject.tag == "Player") //double check tags
	//		{
	//			Debug.Log ("gameOver");
	//			//Destroy (gameObject);
	//			GameController.gameOver = true;// this statement functions correctly but collisions are not being detected
	//
	//		}
	//	}
}
