﻿using UnityEngine;
using System.Collections;

public class igrac : MonoBehaviour {

	
	private bool _isFacingRight;
	private kontrolerzalika _controller;
	private float _normalizedHorizontalSpeed;

	public float MaxSpeed=8;
	public float SpeedAccelerationOnGround =10f;
	public float SpeedAccelerationInAir=5f;

	public void Start(){
		_controller = GetComponent<kontrolerzalika> ();
		_isFacingRight = transform.localScale.x > 0;
	}
	public void Update(){
		HandleInput ();

		var movementFactor = _controller.State.IsGrounded ? SpeedAccelerationOnGround : SpeedAccelerationInAir;
		_controller.SetHorizontalForce(Mathf.Lerp(_controller.Velocity.x,_normalizedHorizontalSpeed*MaxSpeed, Time.deltaTime*movementFactor));
	}

	private void HandleInput()
	{
		if (Input.GetKey (KeyCode.D)) {
						_normalizedHorizontalSpeed = 1;
						if (!_isFacingRight)
								Flip ();} 
		else if (Input.GetKey (KeyCode.A)) {
						_normalizedHorizontalSpeed = -1;
						if (_isFacingRight)
								Flip ();} 
		else {
			_normalizedHorizontalSpeed=0;	
		}

		if (_controller.CanJump && Input.GetKeyDown (KeyCode.Space)) {
			_controller.Jump();		
		}
	}

	private void Flip(){
		transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		_isFacingRight = transform.localScale.x > 0;
	}
}