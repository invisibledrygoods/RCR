using UnityEngine;
using System.Collections.Generic;
using Require;

public class MockUsesButtonInput : UsesButtonInput
{
    List<string> pressed = new List<string>();
    List<string> released = new List<string>();
    List<string> held = new List<string>();

    public void Press(string button)
    {
        pressed.Add(button);
    }
    
    public void Release(string button)
    {
        released.Add(button);
    }

    public void Hold(string button)
    {
        held.Add(button);
    }

    public override bool Pressed(string button)
    {
        return pressed.Contains(button);
    }

    public override bool Released(string button)
    {
        return released.Contains(button);
    }

    public override bool Held(string button)
    {
        return held.Contains(button);
    }

    void LateUpdate()
    {
        pressed = new List<string>();
        released = new List<string>();
        held = new List<string>();
    }
}
