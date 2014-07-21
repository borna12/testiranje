using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class checkpoint : MonoBehaviour {

	private List<IPlayerRespaenListner> _listners;

	public void Awake(){
		_listners = new List<IPlayerRespaenListner> ();
	}

	public void PlayerHitCheckpoint()
	{StartCoroutine(PlayerHitCheckpointCo(levelmanager.Instance.CurrentTimeBonus));
		}

	private IEnumerator PlayerHitCheckpointCo(int bonus)
	{
		FloatingText1.Show ("Checkpoint!","CheckpointText", new centeredTextPositioner(.5f));
		yield return new WaitForSeconds (.5f);
		FloatingText1.Show (string.Format ("+{0} time bonus!",bonus), "CheckpointText", new centeredTextPositioner (.5f));
	}

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
