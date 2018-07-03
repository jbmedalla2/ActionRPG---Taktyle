using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Transform target;
	public Vector3 Offset;
	public float Pitch = 2f; //height
	public float CurrentZoom = 10f;

	//zoom in, zoom out variables
	public float ZoomSpeed = 4f;
	public float MinZoom = 5f;
	public float MaxZoom = 15f;

	//camera rotation variables
	public float YawSpeed = 100f; //rotation speed
	public float CurrentYaw = 190f;

	void Update(){
		ZoomCamera ();
		SetRotation ();
	}

	void LateUpdate(){
		FollowTarget ();
		transform.RotateAround (target.position, Vector3.up, CurrentYaw);
	}

	void SetRotation(){
		CurrentYaw -= Input.GetAxis ("Horizontal") * YawSpeed * Time.deltaTime;
	}

	void ZoomCamera(){
		CurrentZoom -= Input.GetAxis ("Mouse ScrollWheel") * ZoomSpeed;
		CurrentZoom = Mathf.Clamp (CurrentZoom, MinZoom, MaxZoom); //zoom restraints
	}

	void FollowTarget(){
		transform.position = target.position - Offset * CurrentZoom;
		transform.LookAt (target.position + Vector3.up * Pitch);
	}
}