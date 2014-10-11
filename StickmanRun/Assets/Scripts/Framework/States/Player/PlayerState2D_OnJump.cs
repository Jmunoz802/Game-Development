// ================================================
// File: PlayerState2D_OnJump.cs
// Version: 1.0.2
// Desc: Singleton state class inheriting from Istate< >. Do not attach to Gameobject.
//			Applies constant reducing force the longer a key is held down
// ================================================

using UnityEngine;
using System.Collections;

public class PlayerState2D_OnJump : IState<PlayerScript> 
{
    // Data members.
    private bool isAscending;
	private float force;// = 700f;
	private float cumulativeForce;

	private static PlayerState2D_OnJump instance;

    // Properties.
	public static PlayerState2D_OnJump Instance
    {
        get
        {
            if (instance == null)
				instance = new PlayerState2D_OnJump();

            return instance;
        }
    }

    public void Enter(PlayerScript owner)
    {
        Debug.Log("Entering PlayerState_OnJump.");

		//setup variables for jump
		cumulativeForce = 0f;
        isAscending = true;
		force = 900f;
    }

    public void Update(PlayerScript owner)
    {
        if (owner.GameScript.StateMachine.IsInState(GameState_OnPlay.Instance))
        {
			//add cumulative force up to 'force' variable
            if (isAscending)
            {
				//Input must be held down
                if (cumulativeForce < force && InputManager.Instance.isKeyHeldDown(KeyCode.Space))
                {
					float inputforce = (force - cumulativeForce)/4 ;
					cumulativeForce += inputforce;
					owner.Jump(inputforce);
                }
                else
                {
                    isAscending = false;
                }
            }
            else
            {
                // Check if we touched ground.
                if (owner.IsGrounded())
                    owner.StateMachine.ChangeState(PlayerState2D_Running.Instance);
            }
        }
    }

    public void Exit(PlayerScript owner)
    {
        Debug.Log("Exiting PlayerState_OnJump.");
    }
}
