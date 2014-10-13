// ================================================
// File: GameState_OnPlay.cs
// Version: 1.0.1
// Desc: Singleton. Do not attach to Gameobject.
// ================================================

using UnityEngine;
using System.Collections;

public class GameState_OnPlay : IState<GameScript> 
{
    // Data members.
    private static GameState_OnPlay instance;

    // Properties.
    public static GameState_OnPlay Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameState_OnPlay();
            }

            return instance;
        }
    }

    public void Enter(GameScript owner)
    {
        Debug.Log("Entering GameState_OnPlay.");
    }

    public void Update(GameScript owner)
    {

        // Check if player is accessing menu.
        if (owner.PlayerScript.IsAccessingMenu())
        {
            // Change game state to GameState_OnMenu.
            owner.StateMachine.ChangeState(GameState_OnMenu.Instance);
            return;
        }

		//Resets run. Currently for Debugging only
		if (InputManager.Instance.isKeyJustPress(KeyCode.R))
		{
			Application.LoadLevel("StickmanRun");
			return;
		}
    }

    public void Exit(GameScript owner)
    {
        Debug.Log("Exiting GameState_OnPlay.");
    }
}
