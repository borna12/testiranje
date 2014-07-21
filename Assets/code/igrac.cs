﻿using UnityEngine;
using System.Collections;

public class igrac : MonoBehaviour {

	
	private bool _isFacingRight;
	private kontrolerzalika _controller;
	private float _normalizedHorizontalSpeed;

	public float MaxSpeed=8;
	public float SpeedAccelerationOnGround =10f;
	public float SpeedAccelerationInAir=5f;
	public int MaxHealth=100;
	public GameObject OuchEffect;

	public int Health { get; private set;}
	public bool IsDead { get; private set;}

	public void Awake(){
		_controller = GetComponent<kontrolerzalika>();
		_isFacingRight = transform.localScale.x > 0;
		Health = MaxHealth;
	}
	public void Update(){
		if (!IsDead)
		HandleInput ();

		var movementFactor = _controller.State.IsGrounded ? SpeedAccelerationOnGround : SpeedAccelerationInAir;

		if (IsDead)
						_controller.SetHorizontalForce (0);
		else
		_controller.SetHorizontalForce(Mathf.Lerp(_controller.Velocity.x,_normalizedHorizontalSpeed*MaxSpeed, Time.deltaTime*movementFactor));
	}

	public void Kill()
	{
		_controller.HandleCollisions = false;
		collider2D.enabled = false;
		IsDead = true;
		Health = 0;

		_controller.SetForce (new Vector2 (0, 20));

		}
	public void RespawnAt(Transform spawnPoint)
	{
		if (!_isFacingRight)
						Flip ();
		IsDead = false;
		collider2D.enabled = true;
		_controller.HandleCollisions = true;
		Health = MaxHealth;

		transform.position = spawnPoint.position;
		}
	public void TakeDamage(int damage)
	{
		FloatingText1.Show (string.Format ("-{0}", damage), "PlayerTakeDamageText", new fromWorldPintTextPointer (Camera.main, transform.position, 2f, 60f));
		Instantiate (OuchEffect, transform.position, transform.rotation);
		Health -= damage;

		if (Health <= 0)
						levelmanager.Instance.KillPlayer ();
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
