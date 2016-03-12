using UnityEngine;
using System.Collections;

public class NinjaStar : MonoBehaviour {

	//called in UserInputHandler on TouchPhase.Ended (last else statement)
	public float speed = 10f;

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

	public void Spawn(GameObject ninjaStar, Vector3 position, Vector3 target) //expects a gameobject and vector3 position in argument when called
	{
		//Vector3 relativePos = target - transform.position;
		//transform.LookAt (target, Vector3.back);
		Instantiate (ninjaStar,position, Quaternion.LookRotation(target)); //prefab defined in USerInputHandler

	}

	public void SetTrajectory(Vector3 target)
	{
		transform.LookAt (target, Vector3.back);
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
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Enemy Projectile") 
		{
			//Destroy (col.gameObject);
			Destroy (gameObject);
		}
	}
}
