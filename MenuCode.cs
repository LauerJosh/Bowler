using UnityEngine;
using System.Collections;

public class MenuCode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void StartGame()
	{
		Application.LoadLevel(1);
		Debug.Log ("Start Game");
	}
	
	public void NextLevel()
	{
		if(Application.loadedLevel+1 < Application.levelCount)
		{
			Application.LoadLevel (Application.loadedLevel+1);
		}
		else
		{
			Application.LoadLevel (1);
		}
	}
	
	public void MenuLevel()
	{
		Application.LoadLevel(0);
	}
	
	public void Quit()
	{
		Application.Quit();
	}
	
	public void RestartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}		
}
