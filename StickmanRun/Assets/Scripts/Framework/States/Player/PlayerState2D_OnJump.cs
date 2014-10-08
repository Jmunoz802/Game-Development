// ================================================
// File: PlayerState2D_OnJump.cs
// Version: 1.0.1
// Desc: Singleton. Do not attach to Gameobject.
// ================================================

using UnityEngine;
using System.Collections;

public class PlayerState2D_OnJump : IState<PlayerScript> 
{
    // Data members.
    private bool isAscending;
	private float force;// = 700f;
	private float cumulativeForce;

	public float baseY = 0;
	public float topY=0;

	private static PlayerState2D_OnJump instance;

    // Properties.
	public static PlayerState2D_OnJump Instance
    {
        get
        {
            if (instance == null)
            {
				instance = new PlayerState2D_OnJump();
            }

            return instance;
        }
    }

    public void Enter(PlayerScript owner)
    {
        Debug.Log("Entering PlayerState_OnJump.");

        owner.OnGround = false;

        owner.MaxJumpHeight = owner.transform.position.y + owner.jumpHeight;
      
        isAscending = true;

		force = 900f;
		cumulativeForce = 0f;
		baseY = GameObject.Find("MainPlayer").transform.position.y;
    }

    public void Update(PlayerScript owner)
    {
        if (owner.GameScript.StateMachine.IsInState(GameState_OnPlay.Instance))
        {

			KeyboardState currentKeyboardstate = InputManager.Instance.CurrentKeyboardState;
			KeyboardState previousKeyboardstate = InputManager.Instance.PreviousKeyboardState;

			//MouseState currentMouseState = InputManager.Instance.CurrentMouseState;
			// MouseState previoustMouseState = InputManager.Instance.PreviousMouseState;

            if (isAscending)
            {
                if (cumulativeForce < force &&
				    (currentKeyboardstate.IsKeyDown(KeyCode.Space) &&
				 	previousKeyboardstate.IsKeyDown(KeyCode.Space)))
                {
					float inputforce = (force - cumulativeForce)/4 ;
					cumulativeForce += inputforce;
					owner.Jump(inputforce);
					if(GameObject.Find("MainPlayer").transform.position.y > topY )
						topY = GameObject.Find("MainPlayer").transform.position.y;
                }
                else
                {
                    isAscending = false;
                }
            }
            else
            {

                // Check if we touched ground.
                if (owner.OnGround || owner.IsGrounded())
                {
                    owner.StateMachine.ChangeState(PlayerState2D_Running.Instance);
                }
            }
        }
    }

    public void Exit(PlayerScript owner)
    {
        Debug.Log("Exiting PlayerState_OnJump.");
		Debug.Log("height of jump: " + (topY-baseY));
    }
}
