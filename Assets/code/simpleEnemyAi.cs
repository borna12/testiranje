using System.Configuration;
using UnityEngine;

public class simpleEnemyAi : MonoBehaviour, ITakeDamage,IPlayerRespawnListener 
{
    public float Speed;
    public float FireRate = 1;
    public projektil Projectile;
    public GameObject DestroyedEffect;
    public int PointsToGivePlayer;
    public AudioClip ShootSound;

    private kontrolerzalika _controller;
    private Vector2 _direction;
    private Vector2 _startPosition;
    private float _canFireIn;

    public void Start()
    {
        _controller = GetComponent<kontrolerzalika>();
        _direction = new Vector2(-1, 0);
        _startPosition = transform.position;

    }

    public void Update()
    {
        _controller.SetHorizontalForce(_direction.x * Speed);

        if ((_direction.x < 0 && _controller.State.IsCollidingLeft) ||
            (_direction.x > 0 && _controller.State.IsCollidingRight))
        {
            _direction = -_direction;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        if ((_canFireIn -= Time.deltaTime) > 0)
            return;

        var raycast = Physics2D.Raycast(transform.position, _direction, 10, 1 << LayerMask.NameToLayer("igrac"));
        if (!raycast)
            return;

        var projectile = (projektil)Instantiate(Projectile, transform.position, transform.rotation);
        projectile.Initialize(gameObject, _direction, _controller.Velocity);
        _canFireIn = FireRate;

        if (ShootSound != null)
            AudioSource.PlayClipAtPoint(ShootSound,transform.position);

    }

    public void TakeDamage(int damage, GameObject instigator)
    {
        if (PointsToGivePlayer != 0)
        {
            var projectile = instigator.GetComponent<projektil>();
            if (projectile != null && projectile.Owner.GetComponent<igrac>() != null)
            {
                gamemanager.Instance.AddPoints(PointsToGivePlayer);
                FloatingText.Show(string.Format("+{0}!", PointsToGivePlayer), "PointStarText",
                    new FromWorldPointTextPositioner(Camera.main, transform.position, 1.5f, 50));
            }
        }

        Instantiate(DestroyedEffect, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    public void OnPlayerRespawnInThicCheckpoint(checkpoint checkpoint, igrac player)
    {
        _direction = new Vector2(-1, 0);
        transform.localScale = new Vector3(1, 1, 1);
        transform.position = _startPosition;
        gameObject.SetActive(true);
    }
}
