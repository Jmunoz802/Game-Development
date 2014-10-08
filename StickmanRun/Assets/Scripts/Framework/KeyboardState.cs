// ================================================
// File: KeyboardState.cs
// Version: 1.0.1
// Desc: Used to record the state of each key on  
// the keyboard. Do not attach to any GameObject.
// ================================================

using UnityEngine;
using System.Collections;

public class KeyboardState
{
    // Data members.
    private bool[] keys;

    private static int maxKeys = 300;

    // Properties.
    public bool[] Keys
    {
        get { return keys; }
    }

    public static int MaxKeys
    {
        get { return maxKeys; }
    }

    public KeyboardState()
    {
        // Instantiate Array.
        keys = new bool[maxKeys];

        // Initialize values.
        for (int i = 0; i < maxKeys; i++)
        {
            this.keys[i] = false;
        }
    }

    public void Copy(KeyboardState keyboardState)
    {
        // Copy keys' states.
        for (int i = 0; i < maxKeys; i++)
        {
            this.keys[i] = keyboardState.Keys[i];
        }
    }

    public bool IsKeyDown(KeyCode key)
    {
        return keys[(int)key];
    }

    public bool IsKeyUp(KeyCode key)
    {
        return !IsKeyDown(key);
    }
}
