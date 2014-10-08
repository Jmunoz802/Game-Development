// ================================================
// File: MouseState.cs
// Version: 1.0.1
// Desc: Used to record the state of each mouse 
// button. Do not attach to any GameObject.
// ================================================

using UnityEngine;
using System.Collections;

public class MouseState 
{
    // Data members.
    private bool[] mouseButtons;

    private Vector2 delta;
    private Vector2 position;

    private float wheelValue;

    private static int maxMouseButtons = 3;

    // Properties.
    public bool[] Buttons
    {
        get { return mouseButtons; }
    }

    public Vector2 Delta
    {
        get { return delta; }
        set { delta = value; }
    }

    public Vector2 Position
    {
        get { return position; }
        set { position = value; }
    }

    public float WheelValue
    {
        get { return wheelValue; }
        set { wheelValue = value; }
    }

    public static int MaxMouseButtons
    {
        get { return maxMouseButtons; }
    }

    public MouseState()
    {
        // Instantiate Array.
        mouseButtons = new bool[maxMouseButtons];

        // Initialize values.
        for (int i = 0; i < maxMouseButtons; i++)
        {
            this.mouseButtons[i] = false;
        }

        delta = Vector2.zero;
        position = Vector2.zero;

        wheelValue = 0.0f;
    }

    public void Copy(MouseState mouseState)
    {
        // Copy button states.
        for (int i = 0; i < maxMouseButtons; i++)
        {
            this.mouseButtons[i] = mouseState.Buttons[i];
        }

        // Copy delta.
        this.delta = mouseState.Delta;

        // Copy position.
        this.position = mouseState.Position;

        // Copy wheelscroll value.
        this.wheelValue = mouseState.WheelValue;
    }

    public bool IsButtonDown(MouseButton button)
    {
        return mouseButtons[(int)button];
    }

    public bool IsButtonUp(MouseButton button)
    {
        return !IsButtonDown(button);
    }
}
