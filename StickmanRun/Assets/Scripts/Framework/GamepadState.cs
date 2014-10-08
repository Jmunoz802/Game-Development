// ================================================
// File: GamepadState.cs
// Version: 1.0.1
// Desc: Used to record the state of the gamepad 
// buttons. Do not attach to any GameObject.
// ================================================

using UnityEngine;
using System.Collections;

public class GamepadState
{
    // Data members.
    private bool[] buttons;

    private Vector2 leftThumbStick;
    private Vector2 rightThumbStick;

    private Vector2 leftTrigger;
    private Vector2 rightTrigger;

    private static int MAX_BUTTONS = 21;

    // Properties.
    public bool[] Buttons
    {
        get { return buttons; }
    }

    public Vector2 LeftThumbStick
    {
        get { return leftThumbStick; }
        set { leftThumbStick = value; }
    }

    public Vector2 RightThumbStick
    {
        get { return rightThumbStick; }
        set { rightThumbStick = value; }
    }

    public Vector2 LeftTrigger
    {
        get { return leftTrigger; }
        set { leftTrigger = value; }
    }

    public Vector2 RightTrigger
    {
        get { return rightTrigger; }
        set { rightTrigger = value; }
    }

    public GamepadState()
    {
        // Instantiate Array.
        buttons = new bool[MAX_BUTTONS];

        // Initialize values.
        for (int i = 0; i < MAX_BUTTONS; i++)
        {
            this.buttons[i] = false;
        }

        // Initialize structs.
        leftThumbStick = Vector2.zero;
        rightThumbStick = Vector2.zero;
    }

    public void Copy(GamepadState gamepadState)
    {
        // Copy buttons' states.
        for (int i = 0; i < MAX_BUTTONS; i++)
        {
            this.buttons[i] = gamepadState.Buttons[i];
        }

        // Copy ThumbSticks' values.
        this.leftThumbStick = gamepadState.LeftThumbStick;
        this.rightThumbStick = gamepadState.RightThumbStick;

        // Copy Triggers' values.
        this.leftTrigger = gamepadState.LeftTrigger;
        this.rightTrigger = gamepadState.RightTrigger;
    }

    public bool IsButtonDown(GamepadButton button)
    {
        return buttons[(int)button];
    }

    public bool IsButtonUp(GamepadButton button)
    {
        return !IsButtonDown(button);
    }
}
