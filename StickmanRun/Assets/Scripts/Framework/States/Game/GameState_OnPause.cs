// ================================================
// File: GameState_OnPause.cs
// Version: 1.0.1
// Desc: Singleton. Do not attach to Gameobject.
// ================================================

using UnityEngine;
using System.Collections;

public class GameState_OnPause : IState<GameScript> 
{
    // Data members.
    private static GameState_OnPause instance;

    // Properties.
    public static GameState_OnPause Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameState_OnPause();
            }

            return instance;
        }
    }

    public void Enter(GameScript owner)
    {
        Debug.Log("Entering GameState_OnPause.");
    }

    public void Update(GameScript owner)
    {
        // Check if player is unpausing game.
        if (owner.PlayerScript.IsUnpausing())
        {
            // Change game state back to previous state.
            owner.StateMachine.ChangeState(owner.StateMachine.PreviousState);

            return;
        } 
    }

    public void Exit(GameScript owner)
    {
        Debug.Log("Exiting GameState_OnPause.");
    }
}
