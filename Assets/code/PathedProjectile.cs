﻿using UnityEngine;


public class PathedProjectile : MonoBehaviour, ITakeDamage {
	private Transform _destination;
	private float _speed;

	public GameObject DestroyEffect;
	public int PointsToGivePlayer;
    public AudioClip DestroySound;


	public void Initialize(Transform destination, float speed)
	{
		_destination=destination;
		_speed=speed;

	}

	public void Update()
	{
		transform.position = Vector3.MoveTowards (transform.position, _destination.position, Time.deltaTime * _speed);

		var distanceSquared = (_destination.transform.position - transform.position).sqrMagnitude;
		if (distanceSquared > .01f * .01f)
						return;

		if (DestroyEffect != null)
						Instantiate (DestroyEffect, transform.position, transform.rotation);

        if (DestroySound!=null)
            AudioSource.PlayClipAtPoint(DestroySound,transform.position);
		Destroy (gameObject);

	}

	public void TakeDamage(int damage, GameObject instigator)
	{
		if (DestroyEffect != null) {
			Instantiate(DestroyEffect,transform.position,transform.rotation);

		Destroy(gameObject);

			var projectile = instigator.GetComponent<projektil>();
			if (projectile != null && projectile.Owner.GetComponent<igrac>() != null && PointsToGivePlayer !=0)
			{
				gamemanager.Instance.AddPoints(PointsToGivePlayer);
				FloatingText.Show(string.Format("{0}!",PointsToGivePlayer),"PointStarText", new FromWorldPointTextPositioner(Camera.main, transform.position, 1.5f,50));
			}

		}
	}
}
