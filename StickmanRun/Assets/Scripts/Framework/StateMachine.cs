// ================================================
// File: StateMachine.cs
// Version: 1.0.1
// Desc: FSM class. Do not attach to GameObject.
// ================================================

using UnityEngine;
using System.Collections;

public class StateMachine<T>
{
	// Data members
    private T owner;
    private IState<T> previousState;
    private IState<T> currentState;

    //Properties
    public IState<T> CurrentState
    {
        get { return currentState; }
    }

    public IState<T> PreviousState
    {
        get { return previousState; }
    }

    // Ctor.
    public StateMachine(T owner)
    {
        this.owner = owner;
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.Update(owner);
        }
    }

    public void ChangeState(IState<T> state)
    {
        if (state == null)
        {
            return;
        }

        // Keep record of current state
        previousState = currentState;

        if (currentState != null)
        {
            currentState.Exit(owner);
        }

        currentState = state;

        currentState.Enter(owner);
    }

	public void RevertToPreviousState()
    {
        ChangeState(previousState);
    }

    public bool IsInState(IState<T> state)
    {
        return (currentState.Equals(state));
    }
}
