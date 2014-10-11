// ================================================
// File: GameState_OnMenu.cs
// Version: 1.0.1
// Desc: Singleton. Do not attach to Gameobject.
// ================================================

using UnityEngine;
using System.Collections;

public class GameState_OnMenu : IState<GameScript> 
{
    // Data members.
    private static GameState_OnMenu instance;

    // Properties.
    public static GameState_OnMenu Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameState_OnMenu();
            }

            return instance;
        }
    }

    public void Enter(GameScript owner)
    {
        Debug.Log("Entering GameState_OnMenu.");
		Statistics.Instance.pauseTime();
		owner.PlatformScript.activePlatforms = false;
    }

    public void Update(GameScript owner)
    {
        // Check if player is leaving menu.
        if (owner.PlayerScript.IsLeavingMenu())
        {
            // Change game state back to previous state.
            owner.StateMachine.ChangeState(owner.StateMachine.PreviousState);

            return;
        } 
    }

    public void Exit(GameScript owner)
    {
        Debug.Log("Exiting GameState_OnMenu.");
		Statistics.Instance.unpauseTime();
		owner.PlatformScript.activePlatforms = true;
    }
}
