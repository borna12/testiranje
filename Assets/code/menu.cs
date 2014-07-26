using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour
{

    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(2, 30, 120, 20), "Choose Level");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(20, 70, 80, 20), "Level 1"))
        {
            Application.LoadLevel(1);
        }

        // Make the second button.
        if (GUI.Button(new Rect(20, 90, 80, 20), "Level 2"))
        {
            Application.LoadLevel(2);
        }
    }
}