using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_PlayerState
{ 
    Idle,
    Walk,
    Run,
    /// <summary>
    /// »¥¶¯×´Ì¬
    /// </summary>
    Interact,
}
public class BaseState
{
    public virtual void OnEnter() { }
    public virtual void OnUpdate() { }
    public virtual void OnExit() { }
}
