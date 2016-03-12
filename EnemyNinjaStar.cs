using UnityEngine;
using System.Collections;

public class EnemyNinjaStar : MonoBehaviour {
	
	public float speed = 7f;

	public GameObject targetIcon;

	//public Camera camera;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position + transform.forward * speed * Time.deltaTime;
		//newPosition.z = transform.position.z; //keeps it from moving in the z axis
		transform.position = newPosition;
		DestroyIf ();
	}

	public static void Spawn(GameObject ninjaStar, Vector3 position, Vector3 target) //expects a gameobject and vector3 position in argument when called
	{
		//Vector3 relativePos = target - transform.position;
		//transform.LookAt (target, Vector3.back);
		Instantiate (ninjaStar,position, Quaternion.LookRotation(target)); //prefab defined in USerInputHandler
	}

	public void DestroyIf()
	{
		if (gameObject.transform.position.x >= 39 || gameObject.transform.position.x <= -39 || gameObject.transform.position.z >= 309 || gameObject.transform.position.y <= -16) 
		{
			Destroy (gameObject);
		}
	}

	public void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "SlashRange") {
			//Instantiate (targetIcon, new Vector3(transform.position.x, transform.position.y,0f), Quaternion.identity);
			GameObject Reticle = Instantiate(targetIcon) as GameObject;
			//GameObject canvas = GameObject.Find ("GameScreen");
			//Camera camera = Camera.main;
			//Vector2 screenPos = camera.WorldToScreenPoint (transform.position);
			Reticle.transform.SetParent (gameObject.transform, false);
			//Reticle.transform.localPosition = new Vector2 (screenPos.x - Screen.width/2, screenPos.y - Screen.height/2);
		}
		if (col.gameObject.tag == "Projectile" || col.gameObject.tag == "Player") 
		{
			//Instantiate (poof, transform.position, Quaternion.identity);
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
//		if (col.gameObject.tag == "Player") 
//		{
//			Destroy (gameObject);
//			GameController.playerHP --;
//			if (GameController.playerHP <= 0) {
//				GameController.gameOver = true;
//			}
//		}
//	}
}
