using UnityEngine;
using System.Collections;

public class jumpPlatform : MonoBehaviour {
	public float JumpMagnitude = 20;
    public AudioClip JumpSound;

	public void ControllerEnter2D(kontrolerzalika controller)
	{

        if (JumpSound !=null)
            AudioSource.PlayClipAtPoint(JumpSound, transform.position);
		controller.SetVerticalForce (JumpMagnitude);
	}
}
