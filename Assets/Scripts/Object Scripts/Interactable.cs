using UnityEngine;

public class Interactable : MonoBehaviour {
	public float Radius; //How close the player to the object to interact to it
	bool isFocus = false;
	bool hasInteracted = false;
	Transform player;

	public virtual void Interact(){
		Debug.Log ("Interacting with " + player.name);
	}

	void Update(){
		CheckIfInteracted ();
	}

	void CheckIfInteracted(){
		if (isFocus && !hasInteracted) {
			float distance = Vector3.Distance (player.position, transform.position);
			if (distance <= Radius) {
				Interact ();
				hasInteracted = true;
			}
		}
	}

	public void OnFocused(Transform playerTransform){
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
	}

	public void OnDefocused(){
		isFocus = false;
		player = null;
		hasInteracted = false;
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, Radius);
	}
}