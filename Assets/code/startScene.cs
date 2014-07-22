using UnityEngine;
using System.Collections;

public class startScene : MonoBehaviour
{

    public string FirstLevel;

    public void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        gamemanager.Instance.Reset();
        Application.LoadLevel(FirstLevel);


    }
}
