using UnityEngine;
using System.Collections;

public class gamemanager 
{
	public static gamemanager Instance{ get { return null; } }
	public int Points { get; private set;}
	
	public void Reset()
	{}
	
	public void AddPoints(int points)
	{}
}