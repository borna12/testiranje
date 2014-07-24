using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class levelmanager : MonoBehaviour
{
	public static levelmanager Instance { get; private set;}

	public igrac Player { get; private set;}
	public kameraKontrole Camera { get; private set;}
	public TimeSpan RunningTime {get{return DateTime.UtcNow - _started;}}

	public int CurrentTimeBonus
	{
		get{
			var secondDifference=(int)(BonusCutOffSeconds-RunningTime.TotalSeconds);
			return Mathf.Max(0, secondDifference)*BonusSecondMultiplier;
		}
	}

	private List<checkpoint> _checkpoints;
	private int _currentCheckpointIndex;
	private DateTime _started;
	private int _savedPoints;

	public checkpoint DebugSpawn;
	public int BonusCutOffSeconds;
	public int BonusSecondMultiplier;


	public void Awake()
	{
	    _savedPoints = gamemanager.Instance.Points;
		Instance = this;
	}
	public void Start()
	{
				_checkpoints = FindObjectsOfType<checkpoint> ().OrderBy (t => t.transform.position.x).ToList ();
				_currentCheckpointIndex = _checkpoints.Count > 0 ? 0 : -1;

				Player = FindObjectOfType<igrac> ();
				Camera = FindObjectOfType<kameraKontrole> ();

				_started = DateTime.UtcNow;

		var listners = FindObjectsOfType<MonoBehaviour> ().OfType<IPlayerRespawnListener> ();
				foreach (var listener in listners) {
						for (var i = _checkpoints.Count -1; i >=0; i--) {
								var distance = ((MonoBehaviour)listener).transform.position.x - _checkpoints [i].transform.position.x;
								if (distance < 0)
										continue;
				
								_checkpoints[i].AssignObjectToCheckpoint (listener);
								break;
						}
				}


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

		gamemanager.Instance.AddPoints (CurrentTimeBonus);
		_savedPoints = gamemanager.Instance.Points;
		_started = DateTime.UtcNow;

	
		}


    public void GoToNextLevel(string levelName)

    {
    
        StartCoroutine(GoToNextLevelCo(levelName));
    }

    private IEnumerator GoToNextLevelCo(string levelName)
    {
        Player.FinishLevel();
        gamemanager.Instance.AddPoints(CurrentTimeBonus);
        FloatingText.Show("Level completed", "CheckpointText", new centeredTextPositioner(0.1f));
        yield return new WaitForSeconds(1);
        FloatingText.Show(string.Format("{0} points!", gamemanager.Instance.Points), "CheckpointText", new centeredTextPositioner(.1f));
        yield return new WaitForSeconds(5f);

        if (string.IsNullOrEmpty(levelName))
            Application.LoadLevel("StartScreen");
        else
        {
            Application.LoadLevel(levelName);
        }

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

		_started = DateTime.UtcNow;
		gamemanager.Instance.ResetPoints (_savedPoints);
	}

}
