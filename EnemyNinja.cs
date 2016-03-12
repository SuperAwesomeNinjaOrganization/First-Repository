using UnityEngine;
using System.Collections;

public class EnemyNinja : MonoBehaviour {

	public GameObject enemyShuriken;//enemy shuriken goes here

	public GameObject player;

	public GameObject poof;

	Vector3 raisedShurikenPos = new Vector3 (0f, 2.5f, 0f);

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
					StartCoroutine("ShurikenAttack");
				} 
			}
			yield return new WaitForSeconds(2);
		}
	}

	public IEnumerator ShurikenAttack(){
		int caseSwitch = UnityEngine.Random.Range(1,11);

		switch (caseSwitch) 
		{
		case 1:
			//attack
			Debug.Log ("An attack is happening");
			if (transform.position.x <= 0) {
				GetComponent<Animation> ().Play ("Throw_Shuriken_LeftLane");
				yield return new WaitForSeconds (0.5f);
			} else {
				GetComponent<Animation> ().Play ("Throw_Shuriken_RightLane");
				yield return new WaitForSeconds (0.5f);
			}
			EnemyNinjaStar.Spawn (enemyShuriken, transform.position  + raisedShurikenPos, player.transform.position - transform.position - raisedShurikenPos);
			//enemyShuriken.GetComponent<Animation> ().Play("Spin");
			GetComponent<Animation> ().Play ("Run");
			break;
		case 2:
			//do nothing
			Debug.Log("just relaxing");
			break;
		case 3:
			//do nothing
			break;
		case 4:
			//do nothing
			break;
		case 5:
			//do nothing
			break;
		case 6:
			//do nothing
			break;
		case 7:
			//do nothing
			break;
		case 8:
			//do nothing
			break;
		case 9:
			//do nothing
			break;
		case 10:
			//do nothing
			break;
		}
	}

	public static void JumpAttack(){
		Debug.Log ("RASHIDO");
		//speed = 20f;
	}

	public void OnTriggerEnter (Collider col)
	{
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
