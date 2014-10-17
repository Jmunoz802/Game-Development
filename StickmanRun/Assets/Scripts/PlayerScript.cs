// ================================================
// File: PlayerScript.cs
// Version: 1.0.1
// Desc: script controls player input and interaction with other collider objects
// ================================================

using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
{
    // Data members.    
	public GameObject groundChk;
	public LayerMask mask;
	public Animator anim;

    private GameScript gameScript;
    private StateMachine<PlayerScript> stateMachine;

    // Properties.
    public GameScript GameScript
    {
        get { return gameScript; }
    }

    public StateMachine<PlayerScript> StateMachine
    {
        get { return stateMachine; }
    }

    // Called when the script instance is being loaded.
    private void Awake()
    {
		//Get animator component
		anim = this.GetComponent<Animator>();
		anim.SetFloat("Speed", 0.0f);

        // Instantiate StateMachine.
        stateMachine = new StateMachine<PlayerScript>(this);

        // Get Terrain GameObject.
        GameObject gameObject = GameObject.Find("Terrain");

		// Error checking
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
			Debug.LogError("PlayerScript.cs: Game object \"GroundCheck\" not found.");
		}
		else
		{
			groundChk = gameObject;
		}
    }

	// Use this for initialization.
	private void Start () 
    {}
	
	// Update is called once per frame.
	private void Update () 
    {
        // Update StateMachine.
        stateMachine.Update();
	}

    private void OnGUI()
    {}

    public void Jump(float force)
    {
        // Apply jump magnitude.
		rigidbody2D.AddForce(new Vector2(0, force));
    }

    public bool IsJumping()
    {
		// Get input from InputManager.
		return InputManager.Instance.isKeyJustPress(KeyCode.Space);
    }

    public bool IsAccessingMenu()
    {
        // Get input from InputManager.
		return InputManager.Instance.isKeyJustPress(KeyCode.Escape);
    }

    public bool IsLeavingMenu()
    {
		// Get input from InputManager.
		return InputManager.Instance.isKeyJustPress(KeyCode.Escape);
    }

	public bool IsRestartingGame()
	{
		// Get input from InputManager
		return InputManager.Instance.isKeyJustPress(KeyCode.R);
	}

	public bool IsGrounded()
	{
		//use physics2D to check if collider Overlaps at the feet
		Collider2D[] results = new Collider2D[3];
		Vector2 posit = new Vector2(groundChk.transform.position.x, groundChk.transform.position.y);
		if(Physics2D.OverlapCircleNonAlloc(posit, 0.1f, results, mask) >= 1){
			return true;
		}
		return false;
	}

}
