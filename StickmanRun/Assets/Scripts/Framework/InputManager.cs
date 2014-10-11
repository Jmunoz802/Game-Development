// ================================================
// File: InputManager.cs
// Version: 1.0.2
// Desc: Singleton class managing Input for keyboard and mouse.
// ================================================

using UnityEngine;
using System.Collections;

public class InputManager 
{
    // Data members.
    private static InputManager instance;

    private MouseState currentMouseState;
    private MouseState previousMouseState;

    private KeyboardState currentKeyboardState;
    private KeyboardState previousKeyboardState;

    private bool isGamepadActive;
    private bool isMouseActive;
    private bool isKeyboardActive;
    
    // Properties.
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new InputManager();
            }

            return instance;
        }
    }

    public MouseState CurrentMouseState
    {
        get { return currentMouseState; }
    }

    public MouseState PreviousMouseState
    {
        get { return previousMouseState; }
    }

    public KeyboardState CurrentKeyboardState
    {
        get { return currentKeyboardState; }
    }

    public KeyboardState PreviousKeyboardState
    {
        get { return previousKeyboardState; }
    }

    public bool IsGamepadActive
    {
        get { return isGamepadActive; }
        set { isGamepadActive = value; }
    }

    public bool IsMouseActive
    {
        get { return isMouseActive; }
        set 
        { 
            isMouseActive = value;

            if (value == true)
            {
                Screen.showCursor = true;
            }
            else
            {
                Screen.showCursor = false;
            }
        }
    }

    public bool IsKeyboardActive
    {
        get { return isKeyboardActive; }
        set { isKeyboardActive = value; }
    }
    
    public void Poll()
    {
        // Store previous States.
        previousMouseState.Copy(currentMouseState);
        previousKeyboardState.Copy(currentKeyboardState);

        if (IsMouseActive)
        {
            GetMouseInput();
        }

        if (IsKeyboardActive)
        {
            GetKeyboardInput();
        }
    }

	public bool isKeyHeldDown(KeyCode key)
	{
		return currentKeyboardState.IsKeyDown(key) &&
			previousKeyboardState.IsKeyDown(key);
	}

	public bool isKeyJustPress(KeyCode key)
	{
		return currentKeyboardState.IsKeyDown(key) &&
			previousKeyboardState.IsKeyUp(key);
	}

	public bool isKeyJustReleased(KeyCode key)
	{
		return currentKeyboardState.IsKeyUp(key) &&
			previousKeyboardState.IsKeyDown(key);
	}

     // Ctor.
    private InputManager()
    {
        // Reset Input Axes.
        Input.ResetInputAxes();

        // Instantiate MouseStates.
        currentMouseState   = new MouseState();
        previousMouseState  = new MouseState();

        // Instantiate KeyboardStates.
        currentKeyboardState    = new KeyboardState();
        previousKeyboardState   = new KeyboardState();

        // Initialize variables.
        IsGamepadActive = true;
        IsMouseActive = true;
        IsKeyboardActive = true;
    }

    private void GetMouseInput()
    {
        // Get Left Mouse Button input.
        if (Input.GetMouseButton((int)MouseButton.Left))
        {
            currentMouseState.Buttons[(int)MouseButton.Left] = true;
        }
        else
        {
            currentMouseState.Buttons[(int)MouseButton.Left] = false;
        }

        // Get Right Mouse Button input.
        if (Input.GetMouseButton((int)MouseButton.Right))
        {
            currentMouseState.Buttons[(int)MouseButton.Right] = true;
        }
        else
        {
            currentMouseState.Buttons[(int)MouseButton.Right] = false;
        }

        // Get Middle Mouse Button input.
        if (Input.GetMouseButton((int)MouseButton.Middle))
        {
            currentMouseState.Buttons[(int)MouseButton.Middle] = true;
        }
        else
        {
            currentMouseState.Buttons[(int)MouseButton.Middle] = false;
        }

        // Get Mouse Position.
        Vector2 position;

        position.x = Input.mousePosition.x;
        position.y = Input.mousePosition.y;

        currentMouseState.Position = position;
    }

    private void GetKeyboardInput()
    {
        for (int i = 0; i < KeyboardState.MaxKeys; i++)
        {
            if (Input.GetKey((KeyCode)i))
            {
                currentKeyboardState.Keys[i] = true;
            }
            else
            {
                currentKeyboardState.Keys[i] = false;
            }
        }
    }
}

// ================================================
// Enums.
// ================================================
public enum MouseButton
{
    Left = 0,
    Right,
    Middle
};

public enum GamepadButton
{
    A = 0,
    B,
    Back,
    BigButton,
    DpadDown,
    DpadLeft,
    DpadRight,
    DpadUp,
    LShoulder,
    LThumbStickDown,
    LThumbStickLeft,
    LThumbStickRight,
    LThumbStickUp,
    RShoulder,
    RThumbStickDown,
    RThumbStickLeft,
    RThumbStickRight,
    RThumbStickUp,
    Start,
    X,
    Y
}
