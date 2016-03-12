using UnityEngine;
using System.Collections;

public class HouseController : MonoBehaviour {
	//private MoveSpeed = GameLogic.MoveSpeed;
	//Random rand = new Random();
	private float MoveSpeed = -27; //adjust and save as necessary
	public GameObject prefab1;
	public GameObject prefab2;
	public GameObject prefab3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0,MoveSpeed*Time.deltaTime);
		SpawnAndDestroy ();
	}

	void SpawnAndDestroy () {
		if (gameObject.transform.position.z <= -15) {
			//spawn object
			int caseSwitch = UnityEngine.Random.Range(1,4);
			float currentXPos = gameObject.transform.position.x;
			switch (caseSwitch) 
			{
			case 1:
				Instantiate (prefab1, new Vector3(currentXPos,-16,309), Quaternion.identity);
				//Debug.Log (caseSwitch);
				break;
			case 2:
				Instantiate (prefab2, new Vector3(currentXPos,-16,309), Quaternion.identity);
				//Debug.Log (caseSwitch);
				break;
			case 3:
				Instantiate (prefab3, new Vector3(currentXPos,-16,309), Quaternion.identity);
				//Debug.Log (caseSwitch);
				break;
			}
			//destroy object
			Destroy(gameObject);
		}
	}
}
