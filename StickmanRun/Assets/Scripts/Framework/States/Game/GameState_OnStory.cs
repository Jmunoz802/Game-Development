// ================================================
// File: GameState_OnStory.cs
// Version: 1.0.1
// Desc: Singleton. Do not attach to Gameobject.
// ================================================

using UnityEngine;
using System.Collections;

public class GameState_OnStory : IState<GameScript> 
{
    // Data members.
    private static GameState_OnStory instance;

    // Properties.
    public static GameState_OnStory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameState_OnStory();
            }

            return instance;
        }
    }

    public void Enter(GameScript owner)
    {
    }

    public void Update(GameScript owner)
    {
    }

    public void Exit(GameScript owner)
    {
    }
}
