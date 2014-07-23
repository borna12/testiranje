using UnityEngine;

public class instaKill : MonoBehaviour
{
    public AudioClip Kill;

    public void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponent<igrac>();
        if (player == null)
            return;



        if (Kill != null)
            AudioSource.PlayClipAtPoint(Kill, transform.position);
        levelmanager.Instance.KillPlayer();
    }
}

  