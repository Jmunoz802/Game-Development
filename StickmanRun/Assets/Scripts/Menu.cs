// ================================================
// File: Menu.cs
// Version: 1.0.1
// Desc: Do not attach to any GameObject.
// ================================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu
{
    // Data Members.
    private List<MenuItem> items;

    private Vector3 position;

    private int index;

    private float spacing;

    // Properties.
    public List<MenuItem> Items
    {
        get { return items; }
    }

    public Vector3 Position
    {
        get { return position; }
        set { position = value; }
    }

    public int Index
    {
        get { return index; }
        set
        {
            items[index].IsHighlighted = false;

            if (value < 0)
            {
                index = Items.Count - 1;
            }
            else if (value > Items.Count - 1)
            {
                index = 0;
            }
            else
            {
                index = value;
            }

            items[index].IsHighlighted = true;
        }
    }

    public float Spacing
    {
        get { return spacing; }
        set { spacing = value; }
    }

    // Ctor.
    public Menu()
    {
        // Instantiate List.
        items = new List<MenuItem>();

        // Default index.
        index = 0;

        // Default Spacing.
        spacing = 60.0f;
    }

    public void SetToDefault()
    {
        index = 0;

        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetToDefault();
        }
    }
}
