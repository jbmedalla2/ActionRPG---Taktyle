using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour {
	const float animationSmoothTime = 0.1f;
	NavMeshAgent agent;
	Animator animator;

	void Start(){
		agent = GetComponent<NavMeshAgent> ();
		animator = GetComponentInChildren<Animator> ();
	}

	void Update(){
		Animate ();
	}

	void Animate(){
		float SpeedPercent = agent.velocity.magnitude / agent.speed;
		animator.SetFloat ("SpeedPercent", SpeedPercent, animationSmoothTime, Time.deltaTime);
	}
}