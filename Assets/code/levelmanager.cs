using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class levelmanager : MonoBehaviour 
{
	public static levelmanager Instance { get; private set;}

	public igrac Player { get; private set;}
	public kameraKontrole Camera { get; private set;}

	private List<checkpoint> _checkpoints;
	private int _currentCheckpointIndex;

	public checkpoint DebugSpawn;


	public void Awake()
	{
		Instance = this;
	}
	public void Start()
	{
	_checkpoints = FindObjectsOfType<checkpoint>().OrderBy(t => t.transform.position.x).ToList();
	_currentCheckpointIndex = _checkpoints.Count > 0 ? 0 : -1;

		Player = FindObjectOfType<igrac> ();
		Camera = FindObjectOfType<kameraKontrole> ();
#if UNITY_EDITOR
		if (DebugSpawn != null)
						DebugSpawn.SpawnPlayer (Player);
		else if (_currentCheckpointIndex != -1)
				_checkpoints [_currentCheckpointIndex].SpawnPlayer (Player);
#else
		if (_currentCheckpointIndex!=-1)
			_checkpoints[_currentCheckpointIndex].SpawnPlayer(Player);
#endif
	}
	public void Update(){
		var isAtLastCheckPoint = _currentCheckpointIndex + 1 >= _checkpoints.Count;
		if (isAtLastCheckPoint)
						return;
		var distanceToNextCheckpoint = _checkpoints [_currentCheckpointIndex + 1].transform.position.x - Player.transform.position.x;
		if (distanceToNextCheckpoint >=0)
			return;

		_checkpoints [_currentCheckpointIndex].PlayerLeftCheckpoint ();
		_currentCheckpointIndex++;
		_checkpoints [_currentCheckpointIndex].PlayerHitCheckpoint ();

		// TODO: time bonus
	}

	public void KillPlayer(){

		StartCoroutine(KillPlayerCo());

	}

	private IEnumerator KillPlayerCo()
	{
		Player.Kill ();
		Camera.IsFollowing = false;
		yield return new WaitForSeconds (2f);
		
		Camera.IsFollowing = true;
		
		if (_currentCheckpointIndex != -1)
			_checkpoints [_currentCheckpointIndex].SpawnPlayer (Player);
		// TODO: points
	}

}
