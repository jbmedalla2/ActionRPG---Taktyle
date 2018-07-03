using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PlayerRotation))]
public class PlayerMovement : MonoBehaviour {
	NavMeshAgent agent;
	Transform target;
	PlayerRotation rotation;

	void Start(){
		agent = GetComponent<NavMeshAgent> ();
		rotation = GetComponent<PlayerRotation> ();
	}

	void Update(){
		MoveToTarget ();
	}

	public void MoveToPoint(Vector3 point){
		agent.SetDestination (point);
	}

	public void MoveToTarget(){
		if (target != null) {
			agent.SetDestination (target.position);
			rotation.FaceTarget (target);
		}
	}

	public void FollowTarget(Interactable newTarget){
		agent.stoppingDistance = newTarget.Radius * .8f; //set how far the player will stop from the object
		agent.updateRotation = false;
		target = newTarget.transform;
	}

	public void StopFollowingTarget(){
		agent.stoppingDistance = 0f;
		agent.updateRotation = true;
		target = null;
	}
}