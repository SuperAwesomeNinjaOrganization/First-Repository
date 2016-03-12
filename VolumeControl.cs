using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeControl : MonoBehaviour {

	//public float vol = 1f;
	public Slider sliderInstance;

	// Use this for initialization
	void Start () {
		sliderInstance.value = PlayerPrefs.GetFloat ("Volume");
		GetComponent<AudioSource> ().volume = PlayerPrefs.GetFloat ("Volume");
	}
	
//	// Update is called once per frame
//	void Update () {
//	
//	}

	public void OnValueChanged(float value){
		GetComponent<AudioSource> ().volume = value;
		PlayerPrefs.SetFloat ("Volume", value);
		PlayerPrefs.Save ();
		//change the volume
	}
}
