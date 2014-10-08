// ================================================
// File: IState.cs
// Version: 1.0.1
// Desc: Interface.
// ================================================

using UnityEngine;
using System.Collections;

public interface IState<T>
{
    void Enter(T owner);

    void Update(T owner);

    void Exit(T owner);
}
