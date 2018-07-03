using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This will set the (Interactable) objects that was clicked by the player. Set the object to be pickup
[RequireComponent(typeof(PlayerMovement))]
public class PlayerFocus : MonoBehaviour {
	[HideInInspector]
	public Interactable Focus;
	PlayerMovement movement;

	void Start(){
		movement = GetComponent<PlayerMovement> ();
	}

	public void SetFocus(Interactable newFocus){
		//First, Defocus the previous focused object (if there's any)
		if (newFocus != Focus) {
			if (Focus != null)
				Focus.OnDefocused ();
			//Set the new focus
			Focus = newFocus;
			//Set the (Transform) player to itself
			newFocus.OnFocused (transform);
		}
		movement.FollowTarget (newFocus);
	}

	public void RemoveFocus(){
		if (Focus != null)
			Focus.OnDefocused ();
		Focus = null;
		movement.StopFollowingTarget ();
	}
}