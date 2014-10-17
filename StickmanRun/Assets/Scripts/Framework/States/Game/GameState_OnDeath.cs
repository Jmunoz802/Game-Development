// ================================================
// File: GameState_OnDeath.cs
// Version: 1.0.1
// Desc: Singleton state class to handle gamescript functions on player death
// ================================================

using UnityEngine;
using System.Collections;

public class GameState_OnDeath : IState<GameScript> 
{
	// Data members.
	private static GameState_OnDeath instance;
	
	// Properties.
	public static GameState_OnDeath Instance
	{
		get
		{
			if (instance == null)
			{
				instance = new GameState_OnDeath();
			}
			
			return instance;
		}
	}
	
	public void Enter(GameScript owner)
	{
		Debug.Log("Entering GameState_OnDeath.");
		Statistics.Instance.endTime();
		owner.PlatformScript.activePlatforms = false;
		owner.PlatformScript.activeSpawn = false;
	}
	
	public void Update(GameScript owner)
	{
		// Check if player is leaving menu.
		if (owner.PlayerScript.IsLeavingMenu())
		{
			//TODO Change scene to menu scene
			//Application.LoadLevel("MenuScene");
			Application.Quit();
			return;
		} 
		if (owner.PlayerScript.IsRestartingGame())
		{
			Application.LoadLevel("StickmanRun");
			return;
		}

	}

	public void Exit(GameScript owner)
	{
		Debug.Log("Exiting GameState_OnDeath.");
	}
}
