using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerFocus))]
public class PlayerController : MonoBehaviour {
	public LayerMask MovementMask;
	Camera camera;
	PlayerMovement movement;
	PlayerFocus playerFocus;

	void Start(){
		camera = Camera.main;
		movement = GetComponent<PlayerMovement> ();
		playerFocus = GetComponent<PlayerFocus> ();
	}

	void Update(){
		ControlPlayer ();
	}

	void ControlPlayer(){
		Ray ray = camera.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Input.GetMouseButton (0)) {
			//move the player to where the player clicks the mouse. Only if the layer == MovementMask
			if(Physics.Raycast(ray, out hit, 100, MovementMask)){
				//move the character to where we click
				movement.MoveToPoint(hit.point);
				//stop focusing on an (Interactable) object
				playerFocus.RemoveFocus();
			}
		}
		//If player clicked an (INTERACTABLE) object using RMB
		if (Input.GetMouseButton (1)) {
			if (Physics.Raycast (ray, out hit, 100)) {
				Interactable interactable = hit.collider.GetComponent<Interactable> ();
				if (interactable != null)
					playerFocus.SetFocus (interactable);
			}
		}
	}
}