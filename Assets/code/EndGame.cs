using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour
{
    public void Update()
    {

        if (!Input.GetMouseButtonDown(0))
            Application.Quit();

    }
}
