using UnityEngine;
using System.Collections;

public class PointStar : MonoBehaviour, IPlayerRespaenListner {

	public GameObject Effect;
	public int PointsToAdd = 10;

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<igrac> () == null)
						return;
		gamemanager.Instance.AddPoints (PointsToAdd);
		Instantiate (Effect, transform.position, transform.rotation);

		gameObject.SetActive (false);

	}

	public void OnPlayerrespawnInThisCheckPoint(checkpoint checkpoint, igrac player)
	{
		gameObject.SetActive (true);
	}
}
