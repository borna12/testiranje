using UnityEngine;
using System.Collections;

public class kontrolerzalika : MonoBehaviour {

	private const float SkinWidth= .02f;
	private const int TotalHorizontalRays=8;
	private const int TotalVerticalRays=4;

	private static readonly float SlopeLimitTangant = Mathf.Tan (75f * Mathf.Deg2Rad);

	public LayerMask PlatformMask;
	public kontrolerparametar DefaultParameters;

	public kontrolerstanja2d State { get; private set; }

	public void Awake()
	{}
	public void AddForce(Vector2 force)
	{}

	public void SetForce(Vector2 force){}

	public void SetHorizontalForce(float x)
	{}

	public void SetVerticalForce(float y)
	{}

	public void Jump()
	{}

	public void LateUpdate()
	{}
	public void Move(Vector2 deltaMovement)
	{}
	private void HandlePlatforms()
	{}
	private void RaycastOrigons()
	{}
	private void CalcualteRayOrigins()
	{}
	private void MoveHorizontally(ref Vector2 deltaMovement)
	{}
	private void MoveVertically(ref Vector2 deltaMovement)
	{}
	private void HandleVerticalSlope(ref Vector2 deltaMovement)
	{}
	private void HandleHorizontalSlope(ref Vector2 deltaMovement, float angle, bool isGoingRight)
	{}
	public void OnTriggerEnter2D(Collider2D other)
	{}
	public void OnTriggerExit2D(Collider2D other)
	{}

}
	                 
