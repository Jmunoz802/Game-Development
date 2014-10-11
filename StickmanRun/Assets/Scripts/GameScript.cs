// ================================================
// File: GameScript.cs
// Version: 1.0.1
// Desc: Controls major gameplay functionality for the 
// 		StickmanRun action scene
// ================================================

using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour 
{
    // Data members.
    private PlayerScript playerScript;
	private PlatformScript platformScript;
    private Rect messageRect;

    private StateMachine<GameScript> stateMachine;

    // Properties.
    public PlayerScript PlayerScript
    {
        get { return playerScript; }
    }

	public PlatformScript PlatformScript
	{
		get{ return platformScript; }
	}

    public StateMachine<GameScript> StateMachine
    {
        get { return stateMachine; }
    }

    // Called when the script instance is being loaded.
    private void Awake()
    {
        // Instantiate StateMachine.
        stateMachine = new StateMachine<GameScript>(this);
        
        // Get Main Player object.
        GameObject gameObject = GameObject.Find("MainPlayer");

        if (gameObject == null)
        {
            Debug.LogError("GameScript.cs: Game Object \"MainPlayer\" not found.");
        }
        else
        {
            // Get the PlayerScript component attached to GameObject.
            playerScript = gameObject.GetComponent<PlayerScript>();

            if (playerScript == null)
            {
                Debug.LogError("GameScript.cs: PlayerScript component not found.");
            }
        }

		// Get platform Script
		platformScript = GetComponent<PlatformScript>();
		if(platformScript == null)
		{
			Debug.LogError("GameScript.cs: PlatformScript not found on this object!");
		}
		
    }

	// Use this for initialization.
	private void Start () 
    {
        // Set current game state.
        stateMachine.ChangeState(GameState_OnPlay.Instance);

        // Set current player state.
        playerScript.StateMachine.ChangeState(PlayerState2D_Running.Instance);

        // Assign default values.
        messageRect.width = 100;
        messageRect.height = 40;
        messageRect.x = Screen.width / 2 - messageRect.width / 2;
        messageRect.y = Screen.height / 2 - messageRect.height / 2;

		//Assign starting speed for platformscript
		platformScript.PlatformSpeed = 0.09f;
		platformScript.activePlatforms = true;
		platformScript.activeSpawn = true;

		//Start timer for the round
		Statistics.Instance.startTime();
	}
	
	// Update is called once per frame.
	private void Update ()
    {
        // Get Input.
        InputManager.Instance.Poll();

        // Update StateMachine.
        stateMachine.Update();
	}

    private void OnGUI()
    {
        if (stateMachine.IsInState(GameState_OnMenu.Instance))
        {
            GUI.Box(messageRect, "Menu goes here.");
        }
    }
}
