using UnityEngine;
using System.Collections;

public class jumpPlatform : MonoBehaviour {
	public float JumpMagnitude = 20;

	public void ControllerEnter2D(kontrolerzalika controller)
	{
		controller.SetVerticalForce (JumpMagnitude);
	}
}
