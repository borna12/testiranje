using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections;

public class startbutton : MonoBehaviour {

    public string FirstLevel;
	
	// Update is called once per frame
	void OnMouseDown(){

        if (Input.GetMouseButtonDown(0) == true)
        {
     
            Application.LoadLevel(FirstLevel);
        }
	}
}
