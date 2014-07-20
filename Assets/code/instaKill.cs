using UnityEngine;

public class instaKill : MonoBehaviour {
	
	public void OnTriggerEnter2D(Collider2D other){
		var player = other.GetComponents<igrac> ();
		if (player == null)
			return;
		levelmanager.Instance.KillPlayer ();
	}

}
