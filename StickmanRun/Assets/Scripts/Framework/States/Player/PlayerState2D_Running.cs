// ================================================
// File: PlayerState2D_Running.cs
// Version: 1.0.1
// Desc: Singleton. Do not attach to Gameobject.
// ================================================

using UnityEngine;
using System.Collections;

public class PlayerState2D_Running : IState<PlayerScript> {

	private static PlayerState2D_Running instance;

	public float acceleration;
	public float maxSpeed;

	public static PlayerState2D_Running Instance
	{
		get
		{
			if(instance == null)
				instance = new PlayerState2D_Running();

			return instance;
		}
	}

	//Ctor.
	private PlayerState2D_Running()
	{

	}

	// Use this for initialization
	public void Enter (PlayerScript owner) 
	{
		Debug.Log("Entering PlayerState2D_Running");
	}
	
	// Update is called once per frame
	public void Update (PlayerScript owner) 
	{
		if(owner.GameScript.StateMachine.IsInState(GameState_OnPlay.Instance))
		{
			if(owner.IsJumping() || !owner.IsGrounded())
			{
				owner.StateMachine.ChangeState(PlayerState2D_OnJump.Instance);
			}
		}
	}

	public void Exit (PlayerScript owner)
	{
		Debug.Log("Exiting PlayerState2D_Running");
	}

}
