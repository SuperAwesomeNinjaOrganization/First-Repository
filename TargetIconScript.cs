using UnityEngine;
using System.Collections;

public class TargetIconScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("SelfDisappear");
	}
	
//	// Update is called once per frame
//	void Update () {
//		Vector3 newPosition = transform.position + transform.forward * speed * Time.deltaTime;
//		//newPosition.z = transform.position.z; //keeps it from moving in the z axis
//		transform.position = newPosition;
//	
//	}

	public IEnumerator SelfDisappear(){
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
}
