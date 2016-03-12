using UnityEngine;
using System.Collections;

public class PoofScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine ("DePoof");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnumerator DePoof(){
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
}
