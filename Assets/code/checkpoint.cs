using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class checkpoint : MonoBehaviour {

	private List<IPlayerRespaenListner> _listners;

	public void Awake(){
		_listners = new List<IPlayerRespaenListner> ();
	}

	public void PlayerHitCheckpoint(){}

	private IEnumerator PlayerHitCheckpointCo(int bonus)
	{yield break;}

	public void PlayerLeftCheckpoint()
	{}

	public void SpawnPlayer (igrac player)
	{
		player.RespawnAt (transform);

		foreach (var listener in _listners)
						listener.OnPlayerrespawnInThisCheckPoint (this, player);
	}

	public void AssignObjectToCheckpoint(IPlayerRespaenListner listner)
	{
	
		_listners.Add (listner);
	}
}
