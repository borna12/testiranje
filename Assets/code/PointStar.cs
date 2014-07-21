using UnityEngine;


public class PointStar : MonoBehaviour, IPlayerRespaenListner {

	public GameObject Effect;
	public int PointsToAdd = 10;

	public void OnTriggerEnter2D(Collider2D other)
	{
		if (other.GetComponent<igrac>() == null)
						return;
		gamemanager.Instance.AddPoints (PointsToAdd);
		Instantiate (Effect, transform.position, transform.rotation);

		gameObject.SetActive (false);

        FloatingText1.Show(string.Format("+{0}!",PointsToAdd), "PointStarText", 
		                   new fromWorldPintTextPointer(Camera.main, transform.position, 1.5f, 50));


	}

	public void OnPlayerrespawnInThisCheckPoint(checkpoint check, igrac player)
	{
		gameObject.SetActive (true);
	}
}
