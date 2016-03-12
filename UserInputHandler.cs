using UnityEngine;
using System.Collections;

public class UserInputHandler : MonoBehaviour {

	public delegate void TapAction(Touch t); //type that holds a reference to a method
	public static event TapAction OnTap; //message sent to other objects: will get sent to any scripts that register for the event

	public delegate void PanBeganAction(Touch t);
	public static event PanBeganAction OnPanBegan;

	public delegate void PanHeldAction(Touch t);
	public static event PanHeldAction OnPanHeld;

	public delegate void PanEndedAction(Touch t);
	public static event PanEndedAction OnPanEnded;

	//public static bool withinRange = false;

	public float tapMaxMovement = 20f; //max distance finger can move to be still considered a tap (in pixels)

	private Vector2 movement; //keeps track of how far the finger has moved

	private bool tapGestureFailed = false; //will be set to true if tapMaxMovement >= 50f

	public float panMinTime = 0.4f; //minimum amount of time the tap must be held in order to be considered a pan originally 0.4f

	private float startTime; //keep track of time when the gesture begins

	private bool panGestureRecognized = false;

	private bool shurikenThrow = false; //determines if slashing or throwing shuriken

	public GameObject prefab; //put shuriken prefab here

	public GameObject poof;

	NinjaStar ninjaStar = new NinjaStar();

	private float posX = 0f;
	private float posY = 0f;

	// Use this for initialization
	void Start () {
	
	}
	// Note: replace touch with mouseDown etc for testing
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0) //check if any touches are occuring
		{
			Touch touch = Input.touches[0]; //array of touches currently on the screen (for multiple fingers)

			if (Time.timeScale == 1f && touch.phase == TouchPhase.Began) //TouchPhase.Began @ first frame the finger touches the screen
			{
				shurikenThrow = false;
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position); //generates ray to slash/block enemy or set shurikenThrow = true
				//Debug.Log (ray.origin); can I use touch.position instead of Input.GetTouch (0).position?

				RaycastHit hit;

				if (Physics.Raycast (ray, out hit, 10f)) {
					if (hit.collider != null && hit.collider.name == "Ninja_Star_v1") {
						shurikenThrow = true; //do I need this?
						//Instantiate (prefab1, new Vector3(0,0,66), Quaternion.identity);
					} else if (hit.collider != null && hit.collider.tag == "Enemy Projectile" || hit.collider.tag == "Enemy"){
						if (hit.collider.tag == "Enemy") {
							Destroy (hit.collider.gameObject);
							GameLogic.Score++;
						} else if (hit.collider.tag == "Enemy Projectile") {
							Destroy (hit.collider.gameObject);
							GameLogic.Score++;
						}
					}
				} else {
					shurikenThrow = false;
				}

				movement = Vector2.zero; //when touch first begins, set "movement" to zero
				startTime = Time.time; //sets startTime to current time
			}
			else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary) //if touch has moved, or is stationary
			{
				movement += touch.deltaPosition; //increment the amount that the touch has moved "touch.deltaPosition"(in pixels)

				if (!panGestureRecognized && Time.time - startTime > panMinTime) //checks to see if gesture is a pan
				{
					panGestureRecognized = true;
					tapGestureFailed = true;

					if (OnPanBegan != null) //checks if there are any scripts registered to this event (if yes then procceed)
						OnPanBegan(touch); //send OnPanBegan event message
				}
				else if (panGestureRecognized)// if pan gesture was already recognized
				{
					if (OnPanHeld != null)
						OnPanHeld(touch); //send OnPanHeld instead of OnPanBegan
				}
				else if (movement.magnitude > tapMaxMovement) //compare with max allowable finger movement "tapMaxMovement" for a tap
					tapGestureFailed = true; //gesture is not a tap
			}
			else
			{
				if (shurikenThrow) 
				{
					//shoot a shuriken to touch.position
					//Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
					if (touch.position.x < Screen.width / 2) { //sets middle of screen as origin
						posX = ((Screen.width / 2) - touch.position.x) * -1;
					} else {
						posX = touch.position.x - (Screen.width / 2);
					}
						
					posY = touch.position.y/2f - 100f; //controls how high the shuriken will go on swipe

					Vector3 targetPoint = new Vector3(posX,posY,touch.position.y);//Camera.main.ScreenToWorldPoint(touch.position);
					ninjaStar.Spawn (prefab, new Vector3 (0f, 0.1f, 1.7f), targetPoint); //spawns ninja star at middle position
					//ninjaStar.SetTrajectory(targetPoint);
					//Instantiate (prefab1, new Vector3(0,0.1,1.7), Quaternion.identity);
					shurikenThrow = false;
				}

				if (panGestureRecognized)
				{
					if (OnPanEnded != null)
						OnPanEnded(touch);
				}
				else if (!tapGestureFailed)
				{
					if (OnTap != null) //check if OnTap is null which occurs when no other scripts have registered for this event
						OnTap(touch); //send OnTap event message
				}

				panGestureRecognized = false;
				tapGestureFailed = false; //prep for next touch
			}
		}
	}
}
