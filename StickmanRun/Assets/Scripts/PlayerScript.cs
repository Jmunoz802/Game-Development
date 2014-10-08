// ================================================
// File: PlayerScript.cs
// Version: 1.0.1
// Desc: 
// ================================================

using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
    // Public Members.
    public float gravity = 20.0f;
    public float jumpHeight = 8.0f;
    public float jumpSpeed = 40.0f;

    // Data members.
    private bool onGround;

    private float maxJumpHeight;
    
	public GameObject groundChk;
	public LayerMask mask;

    private GameScript gameScript;
    private StateMachine<PlayerScript> stateMachine;
    private Vector2 moveDirection;
	private Animator anim;

    // Properties.
    public bool OnGround
    {
        get { return onGround; }
        set { onGround = value; }
    }

    public float MaxJumpHeight
    {
        get { return maxJumpHeight; }
        set { maxJumpHeight = value; }
    }

    public GameScript GameScript
    {
        get { return gameScript; }
    }

    public StateMachine<PlayerScript> StateMachine
    {
        get { return stateMachine; }
    }

    public Vector3 MoveDirection
    {
        get { return moveDirection; }
        set { moveDirection = value; }
    }

    // Called when the script instance is being loaded.
    private void Awake()
    {
		//Get animator component
		anim = this.GetComponent<Animator>();
		anim.SetFloat("Speed", 1.0f);

        // Instantiate StateMachine.
        stateMachine = new StateMachine<PlayerScript>(this);

        // Get Terrain GameObject.
        GameObject gameObject = GameObject.Find("Terrain");

        if (gameObject == null)
        {
            Debug.LogError("PlayerScript.cs: Game Object \"Terrain\" not found.");
        }
        else
        {
            // Get the GameScript component attached to the GameObject.
            gameScript = gameObject.GetComponent<GameScript>();

            if (gameScript == null)
            {
                Debug.LogError("PlayerScript.cs: GameScript component not found.");
            }
        }

		gameObject = GameObject.Find("GroundCheck");
		if(gameObject == null)
		{
			Debug.LogError("PlayerScript.cs: Game object 'GroundCheck' not found.");
		}
		else
		{
			groundChk = gameObject;
		}
    }

	// Use this for initialization.
	private void Start () 
    {
        // Default values.
        moveDirection = Vector3.zero;
	}
	
	// Update is called once per frame.
	private void Update () 
    {
        // Update StateMachine.
        stateMachine.Update();
	}

    private void OnGUI()
    {
    }

    public void ApplyGravity()
    {
        // Get elpased time.
        //float delta = Time.deltaTime;

        // Apply gravity.
        //moveDirection.y -= gravity * delta;
    }

    public void Jump(float force)
    {
        // Get elapsed time.
        //float delta = Time.deltaTime;

        // Apply jump magnitude.
		rigidbody2D.AddForce(new Vector2(0, force));
    }

    public void Move()
    {
        // Move Controller.
		//rigidbody2D.AddForce(moveDirection);

        // Check if player is grounded.

		//isGrounded = ((flags & CollisionFlags.CollidedBelow) != 0);
		//Debug.Log("isGrounded: " + isGrounded);

		//isGrounded = Physics2D.OverlapCircleNonAlloc(groundChk.transform.position, 0.5f, mask);

    }

    public bool IsJumping()
    {
        // Get input from InputManager.
        KeyboardState currentKeyboardState = InputManager.Instance.CurrentKeyboardState;
        KeyboardState previousKeyboardState = InputManager.Instance.PreviousKeyboardState;

        if (currentKeyboardState.IsKeyDown(KeyCode.Space) &&
           previousKeyboardState.IsKeyUp(KeyCode.Space))
        {
            return true;
        }

        return false;
    }

    public bool IsPausing()
    {
        // Get input from InputManager.
        KeyboardState previousKeyboardState = InputManager.Instance.PreviousKeyboardState;
        KeyboardState currentKeyboardState = InputManager.Instance.CurrentKeyboardState;

        if (currentKeyboardState.IsKeyDown(KeyCode.P) &&
            previousKeyboardState.IsKeyUp(KeyCode.P))
        {
            return true;
        }

        return false;
    }

    public bool IsUnpausing()
    {
        // Get input from InputManager.
        KeyboardState previousKeyboardState = InputManager.Instance.PreviousKeyboardState;
        KeyboardState currentKeyboardState = InputManager.Instance.CurrentKeyboardState;

        if (currentKeyboardState.IsKeyDown(KeyCode.P) &&
            previousKeyboardState.IsKeyUp(KeyCode.P))
        {
            return true;
        }

        return false;
    }

    public bool IsAccessingMenu()
    {
        // Get input from InputManager.
        KeyboardState previousKeyboardState = InputManager.Instance.PreviousKeyboardState;
        KeyboardState currentKeyboardState = InputManager.Instance.CurrentKeyboardState;

        if (currentKeyboardState.IsKeyDown(KeyCode.M) &&
            previousKeyboardState.IsKeyUp(KeyCode.M))
        {
            return true;
        }

        return false;
    }

    public bool IsLeavingMenu()
    {
        // Get input from InputManager.
        KeyboardState previousKeyboardState = InputManager.Instance.PreviousKeyboardState;
        KeyboardState currentKeyboardState = InputManager.Instance.CurrentKeyboardState;

        if (currentKeyboardState.IsKeyDown(KeyCode.M) &&
            previousKeyboardState.IsKeyUp(KeyCode.M))
        {
            return true;
        }

        return false;
    }

	public bool IsGrounded()
	{
		Collider2D[] results = new Collider2D[3];
		Vector2 posit = new Vector2(groundChk.transform.position.x, groundChk.transform.position.y);
		if(Physics2D.OverlapCircleNonAlloc(posit, 0.1f, results, mask) >= 1){
			onGround = true;
			//Debug.Log("result: " + results[0].name);
			return true;
		}
		return false;
	}

	private void flipSprite()
	{
		Vector3 newScale = transform.localScale;
		newScale.x *= -1;
		transform.localScale = newScale;
	}

}
