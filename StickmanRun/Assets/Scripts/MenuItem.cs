// ================================================
// File: MenuItem.cs
// Version: 1.0.1
// Desc: Do not attach to any GameObject.
// ================================================

using UnityEngine;
using System.Collections;

public class MenuItem
{
    // Data Members.
    private bool isHighlighted;
    private bool isSelected;

    private Rect position;
    private GUIContent content;
    private GUIStyle style;

    private float width;
    private float height;

    // Properties.
    public bool IsHighlighted
    {
        get { return isHighlighted; }
        set 
        {
            if (value)
            {
                isHighlighted   = true;
                isSelected      = false;
            }
            else
            {
                isHighlighted = false;
            }
             
        }
    }

    public bool IsSelected
    {
        get { return isSelected; }
        set 
        {
            if (value)
            {
                isHighlighted   = false;
                isSelected      = true;
            }
            else
            {
                isSelected = false;
            } 
        }
    }

    public Rect Position
    {
        get { return position; }
        set { position = value; }
    }

    public GUIContent Content
    {
        get { return content; }
        set { content = value; }
    }

    public GUIStyle Style
    {
        get { return style; }
        set { style = value; }
    }

    public float Width
    {
        get { return width; }
        set { width = value; }
    }

    public float Height
    {
        get { return height; }
        set { height = value; }
    }

    public MenuItem()
    {
        // Default value;
        isSelected      = false;
        isHighlighted   = false;
    }

    public void SetToDefault()
    {
        // Default value;
        isSelected      = false;
        isHighlighted   = false;
    }
}