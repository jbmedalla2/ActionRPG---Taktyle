using UnityEngine;

public class ItemPickup : Interactable {
	public override void Interact(){
		base.Interact ();
		Pickup ();
	}

	void Pickup(){
		Debug.Log ("Picking up a " + name);
		//Destroy (gameObject);
	}
}
