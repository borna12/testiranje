using UnityEngine;

public class PointStar : MonoBehaviour, IPlayerRespawnListener
{
    public GameObject Effect;
    public int PointsToAdd = 10;
    public AudioClip HitStarSound;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<igrac>() == null)
            return;
        if  (HitStarSound!= null)
            AudioSource.PlayClipAtPoint(HitStarSound, transform.position);
        gamemanager.Instance.AddPoints(PointsToAdd);
        Instantiate(Effect, transform.position, transform.rotation);

        gameObject.SetActive(false);

        FloatingText.Show(string.Format("+{0}!", PointsToAdd), "PointStarText",
            new FromWorldPointTextPositioner(Camera.main, transform.position, 1.5f, 50));
    }
    public void OnPlayerRespawnInThicCheckpoint(checkpoint checkpoint, igrac player)
    {
        gameObject.SetActive(true);
    }
}