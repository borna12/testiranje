using UnityEngine;
using System.Collections;

public class gamemanager 
{
	private static gamemanager _instance;
	public static gamemanager Instance{ get { return _instance ?? (_instance=new gamemanager()); } }
	public int Points { get; private set;}

	private gamemanager(){

	}
	
	public void Reset()
	{}

	public void ResetPoints(int points)
	{
		Points = points;
		}
	
	public void AddPoints(int pointsToAdd)
	{
		Points += pointsToAdd;
	}
}