using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
	//Rotate the player facing the clicked object (item/enemy/etc). This will also be use for objects that are moving (like enemies)
	public void FaceTarget(Transform target){
		Vector3 direction = (target.position - transform.position).normalized; //direction towards the target
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3 (direction.x, 0, direction.z)); //how to rotate the player to look the target
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); //for smooth rotation
	}
}