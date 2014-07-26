using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]

public class pauza : MonoBehaviour
{
 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)==true)
        {
            
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                audio.Pause();

            }
            else
            {
                Time.timeScale = 1;
                audio.PlayScheduled(1);
            }
        }
    }
}